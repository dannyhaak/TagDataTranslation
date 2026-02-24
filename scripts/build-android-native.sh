#!/bin/bash
set -euo pipefail

# Build NativeAOT shared libraries for Android (arm64-v8a + x86_64).
# Prerequisites:
#   - .NET 10 SDK with android workload
#   - Android NDK (provides lld linker for cross-compilation)
#     Install via: brew install android-ndk
#     Or: sdkmanager "ndk;27.0.12077973"
#
# Usage: ./scripts/build-android-native.sh

SCRIPT_DIR="$(cd "$(dirname "$0")" && pwd)"
ROOT_DIR="$(cd "$SCRIPT_DIR/.." && pwd)"
PROJECT="$ROOT_DIR/sdk/android-native/TagDataTranslation.AndroidNative.csproj"
PUBLISH_BASE="$ROOT_DIR/sdk/android-native/bin/Release/net10.0"
FLUTTER_JNILIBS="$ROOT_DIR/sdk/flutter/tag_data_translation/android/src/main/jniLibs"

echo "=== Building TagDataTranslation for Android arm64-v8a ==="
dotnet publish "$PROJECT" -c Release -r android-arm64

echo ""
echo "=== Building TagDataTranslation for Android x86_64 ==="
dotnet publish "$PROJECT" -c Release -r android-x64

echo ""
echo "=== Copying to Flutter plugin jniLibs ==="
mkdir -p "$FLUTTER_JNILIBS/arm64-v8a" "$FLUTTER_JNILIBS/x86_64"
cp "$PUBLISH_BASE/android-arm64/publish/TagDataTranslation.AndroidNative.so" \
   "$FLUTTER_JNILIBS/arm64-v8a/libtagdatatranslation.so"
cp "$PUBLISH_BASE/android-x64/publish/TagDataTranslation.AndroidNative.so" \
   "$FLUTTER_JNILIBS/x86_64/libtagdatatranslation.so"

echo ""
echo "=== Build complete ==="
echo "arm64-v8a: $FLUTTER_JNILIBS/arm64-v8a/libtagdatatranslation.so"
echo "x86_64:    $FLUTTER_JNILIBS/x86_64/libtagdatatranslation.so"
