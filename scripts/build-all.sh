#!/bin/bash
set -euo pipefail

# Build all SDK targets.
# Usage: ./scripts/build-all.sh

SCRIPT_DIR="$(cd "$(dirname "$0")" && pwd)"
ROOT_DIR="$(cd "$SCRIPT_DIR/.." && pwd)"

echo "=== Building TagDataTranslation (all .NET targets) ==="
dotnet build "$ROOT_DIR/src/TagDataTranslation/TagDataTranslation.csproj" -c Release
echo ""

echo "=== Running tests ==="
dotnet test "$ROOT_DIR/test/TagDataTranslation.Tests/TagDataTranslation.Tests.csproj" -c Release
echo ""

echo "=== Building console example ==="
dotnet build "$ROOT_DIR/examples/ConsoleApp/ConsoleApp.csproj" -c Release
echo ""

echo "=== Packing NuGet ==="
dotnet pack "$ROOT_DIR/src/TagDataTranslation/TagDataTranslation.csproj" -c Release -o "$ROOT_DIR/artifacts/nuget"
echo ""

echo "=== Building Android SDK ==="
dotnet build "$ROOT_DIR/sdk/android/TagDataTranslation.Android.csproj" -c Release
echo ""

echo "=== Building iOS SDK ==="
dotnet build "$ROOT_DIR/sdk/ios/TagDataTranslation.iOS.csproj" -c Release
echo ""

echo ""
echo "=== All builds complete ==="
echo "NuGet package: artifacts/nuget/"
echo ""
echo "Platform-specific packaging:"
echo "  npm:          cd npm && node scripts/build.js"
echo "  Maven:        ./scripts/publish-maven.sh"
echo "  XCFramework:  ./scripts/build-xcframework.sh"
