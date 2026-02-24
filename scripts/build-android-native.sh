#!/bin/bash
set -euo pipefail

# Build NativeAOT shared libraries for Android (arm64-v8a + x86_64).
# Prerequisites:
#   - .NET 10 SDK
#   - Android NDK (via dotnet workload install android)
#
# Usage: ./scripts/build-android-native.sh

SCRIPT_DIR="$(cd "$(dirname "$0")" && pwd)"
ROOT_DIR="$(cd "$SCRIPT_DIR/.." && pwd)"
PROJECT="$ROOT_DIR/sdk/android-native/TagDataTranslation.AndroidNative.csproj"
OUTPUT_DIR="$ROOT_DIR/artifacts/android-native"

echo "=== Building TagDataTranslation for Android arm64-v8a ==="
dotnet publish "$PROJECT" \
    -c Release \
    -r linux-bionic-arm64 \
    -o "$OUTPUT_DIR/arm64-v8a"

echo ""
echo "=== Building TagDataTranslation for Android x86_64 ==="
dotnet publish "$PROJECT" \
    -c Release \
    -r linux-bionic-x64 \
    -o "$OUTPUT_DIR/x86_64"

echo ""
echo "=== Build complete ==="
echo "arm64-v8a: $OUTPUT_DIR/arm64-v8a/"
echo "x86_64:    $OUTPUT_DIR/x86_64/"
echo ""
echo "Shared libraries:"
find "$OUTPUT_DIR" -name "*.so" -type f 2>/dev/null || echo "(no .so files found -- check build output)"
