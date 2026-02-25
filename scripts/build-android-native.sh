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

# find lld linker from Android NDK (required for NativeAOT cross-compilation)
if [ -z "${ANDROID_NDK_HOME:-}" ]; then
    # try common locations: homebrew cask (.app bundle), Android Studio SDK, linux
    NDK_DIR=""
    for candidate in \
        /opt/homebrew/Caskroom/android-ndk/*/AndroidNDK*.app/Contents/NDK \
        "$HOME/Library/Android/sdk/ndk"/*/ \
        /usr/local/lib/android/sdk/ndk/*/; do
        if [ -d "$candidate/toolchains" ] 2>/dev/null; then
            NDK_DIR="$candidate"
            break
        fi
    done
    ANDROID_NDK_HOME="${NDK_DIR:-}"
fi

if [ -n "$ANDROID_NDK_HOME" ]; then
    # detect host platform
    case "$(uname -s)-$(uname -m)" in
        Darwin-*)    HOST_TAG="darwin-x86_64" ;;
        Linux-x86*)  HOST_TAG="linux-x86_64" ;;
        *)           HOST_TAG="linux-x86_64" ;;
    esac
    NDK_LLVM_BIN="$ANDROID_NDK_HOME/toolchains/llvm/prebuilt/$HOST_TAG/bin"
    if [ -d "$NDK_LLVM_BIN" ]; then
        export PATH="$NDK_LLVM_BIN:$PATH"
        echo "Using NDK lld from: $NDK_LLVM_BIN"
    fi
fi

# verify lld is available
if ! command -v ld.lld &>/dev/null; then
    echo "ERROR: ld.lld not found. Set ANDROID_NDK_HOME or install Android NDK."
    echo "  brew install android-ndk"
    echo "  OR: sdkmanager \"ndk;27.0.12077973\""
    exit 1
fi

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
