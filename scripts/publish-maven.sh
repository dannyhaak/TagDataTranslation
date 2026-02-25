#!/bin/bash
set -euo pipefail

# Build and publish the Android SDK to Maven Central.
# Prerequisites:
#   - .NET 10 SDK with android workload
#   - Maven Central credentials in ~/.gradle/gradle.properties
#
# Usage: ./scripts/publish-maven.sh [version]

SCRIPT_DIR="$(cd "$(dirname "$0")" && pwd)"
ROOT_DIR="$(cd "$SCRIPT_DIR/.." && pwd)"
VERSION="${1:-3.0.0}"
OUTPUT_DIR="$ROOT_DIR/artifacts/android"

echo "=== Building TagDataTranslation.Android v${VERSION} ==="

# build the .NET Android library
# note: .NET Android class libraries don't copy DLLs to -o; build normally and copy
BUILD_DIR="$ROOT_DIR/sdk/android/bin/Release/net10.0-android"
dotnet build "$ROOT_DIR/sdk/android/TagDataTranslation.Android.csproj" -c Release

mkdir -p "$OUTPUT_DIR/build"
cp "$BUILD_DIR/TagDataTranslation.Android.dll" "$OUTPUT_DIR/build/"
cp "$BUILD_DIR/TagDataTranslation.dll" "$OUTPUT_DIR/build/"

echo ""
echo "=== Build complete ==="
echo "Output: $OUTPUT_DIR/build/"
ls -lh "$OUTPUT_DIR/build/"*.dll
echo ""
echo "To publish to Maven Central:"
echo "  1. Package as .aar with the Gradle wrapper in the output directory"
echo "  2. Upload to https://central.sonatype.com/"
echo ""
echo "Maven coordinates:"
echo "  groupId:    nl.mimasu"
echo "  artifactId: tag-data-translation"
echo "  version:    ${VERSION}"
