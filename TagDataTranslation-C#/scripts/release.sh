#!/bin/bash
set -euo pipefail

# Release TagDataTranslation to all package registries.
#
# This script builds, tests, and publishes to:
#   1. NuGet (.NET, .NET MAUI)
#   2. npm (JavaScript/TypeScript via WebAssembly)
#   3. Maven Central (Android) -- build only, manual upload
#   4. CocoaPods/SPM (iOS) -- build only, manual upload
#
# Prerequisites:
#   - .NET 10 SDK with maui, wasm-tools workloads
#   - Node.js 18+
#   - Xcode 15+ (for iOS)
#   - NuGet API key in ~/.nuget/nuget-apikey.txt
#   - npm login (or NPM_TOKEN env var)
#
# Usage:
#   ./scripts/release.sh              # publish all
#   ./scripts/release.sh --dry-run    # build and test only, don't publish
#   ./scripts/release.sh nuget        # publish NuGet only
#   ./scripts/release.sh npm          # publish npm only
#   ./scripts/release.sh nuget npm    # publish NuGet and npm

SCRIPT_DIR="$(cd "$(dirname "$0")" && pwd)"
ROOT_DIR="$(cd "$SCRIPT_DIR/.." && pwd)"
DRY_RUN=false
TARGETS=()

# parse arguments
for arg in "$@"; do
    case "$arg" in
        --dry-run) DRY_RUN=true ;;
        nuget|npm|maven|ios) TARGETS+=("$arg") ;;
        *) echo "Unknown argument: $arg"; echo "Usage: $0 [--dry-run] [nuget] [npm] [maven] [ios]"; exit 1 ;;
    esac
done

# default: all targets
if [[ ${#TARGETS[@]} -eq 0 ]]; then
    TARGETS=(nuget npm maven ios)
fi

VERSION=$(grep '<Version>' "$ROOT_DIR/TagDataTranslation/TagDataTranslation.csproj" | sed 's/.*<Version>\(.*\)<\/Version>.*/\1/')
echo "========================================"
echo "  TagDataTranslation v${VERSION}"
echo "  Targets: ${TARGETS[*]}"
if $DRY_RUN; then echo "  Mode: DRY RUN (no publishing)"; fi
echo "========================================"
echo ""

# step 1: run tests (always)
echo "=== Running unit tests ==="
dotnet test "$ROOT_DIR/TagDataTranslationUnitTest/TagDataTranslationUnitTest.csproj" -c Release --verbosity quiet
echo "Tests passed."
echo ""

# track results
declare -A RESULTS

# --- NuGet ---
publish_nuget() {
    echo "=== NuGet: Building and packing ==="
    dotnet pack "$ROOT_DIR/TagDataTranslation/TagDataTranslation.csproj" \
        -c Release \
        -o "$ROOT_DIR/artifacts/nuget"

    NUPKG=$(ls "$ROOT_DIR/artifacts/nuget"/TagDataTranslation.*.nupkg | head -1)
    echo "Package: $NUPKG"

    if $DRY_RUN; then
        echo "DRY RUN: skipping NuGet push"
        RESULTS[nuget]="built (dry run)"
    else
        NUGET_KEY=""
        if [[ -f "$HOME/.nuget/nuget-apikey.txt" ]]; then
            NUGET_KEY=$(cat "$HOME/.nuget/nuget-apikey.txt")
        elif [[ -n "${NUGET_API_KEY:-}" ]]; then
            NUGET_KEY="$NUGET_API_KEY"
        else
            echo "ERROR: No NuGet API key found."
            echo "  Set NUGET_API_KEY env var or create ~/.nuget/nuget-apikey.txt"
            RESULTS[nuget]="FAILED (no API key)"
            return
        fi
        dotnet nuget push "$NUPKG" \
            --source https://api.nuget.org/v3/index.json \
            --api-key "$NUGET_KEY"
        RESULTS[nuget]="published"
    fi
    echo ""
}

# --- npm ---
publish_npm() {
    echo "=== npm: Building WASM ==="
    if ! command -v node &> /dev/null; then
        echo "ERROR: Node.js not found. Skipping npm."
        RESULTS[npm]="FAILED (no Node.js)"
        return
    fi

    node "$ROOT_DIR/npm/scripts/build.js"
    echo ""

    echo "=== npm: Running smoke test ==="
    node "$ROOT_DIR/npm/test/smoke.js"
    echo ""

    if $DRY_RUN; then
        echo "DRY RUN: skipping npm publish"
        RESULTS[npm]="built (dry run)"
    else
        cd "$ROOT_DIR/npm"
        npm publish --access public
        cd "$ROOT_DIR"
        RESULTS[npm]="published"
    fi
    echo ""
}

# --- Maven (Android) ---
publish_maven() {
    echo "=== Maven: Building Android SDK ==="
    dotnet publish "$ROOT_DIR/TagDataTranslation.Android/TagDataTranslation.Android.csproj" \
        -c Release \
        -o "$ROOT_DIR/artifacts/android/build"

    RESULTS[maven]="built (manual upload required)"
    echo ""
    echo "Android SDK built to: artifacts/android/build/"
    echo "Manual steps to publish to Maven Central:"
    echo "  1. Package as .aar with Gradle"
    echo "  2. Upload to https://central.sonatype.com/"
    echo "  Coordinates: nl.mimasu:tag-data-translation:${VERSION}"
    echo ""
}

# --- iOS (CocoaPods / SPM) ---
publish_ios() {
    echo "=== iOS: Building XCFramework ==="
    "$SCRIPT_DIR/build-xcframework.sh"

    echo ""
    echo "=== iOS: Creating release zip ==="
    cd "$ROOT_DIR/artifacts/ios"
    zip -r TagDataTranslation.xcframework.zip TagDataTranslation.xcframework
    cd "$ROOT_DIR"

    RESULTS[ios]="built (upload zip to GitHub Release)"
    echo ""
    echo "XCFramework zip: artifacts/ios/TagDataTranslation.xcframework.zip"
    echo "Manual steps:"
    echo "  1. Upload zip to GitHub Release v${VERSION}"
    echo "  2. Update checksum in swift/Package.swift"
    echo "  3. pod trunk push swift/TagDataTranslation.podspec"
    echo ""
}

# run selected targets
for target in "${TARGETS[@]}"; do
    case "$target" in
        nuget) publish_nuget ;;
        npm)   publish_npm ;;
        maven) publish_maven ;;
        ios)   publish_ios ;;
    esac
done

# summary
echo "========================================"
echo "  Release Summary -- v${VERSION}"
echo "========================================"
for target in "${TARGETS[@]}"; do
    printf "  %-8s %s\n" "$target:" "${RESULTS[$target]:-skipped}"
done
echo ""
if $DRY_RUN; then
    echo "This was a dry run. Re-run without --dry-run to publish."
fi
