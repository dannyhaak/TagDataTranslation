#!/bin/bash
set -euo pipefail

# Build a universal XCFramework for iOS (arm64 device + arm64 simulator).
# Prerequisites:
#   - .NET 10 SDK
#   - Xcode 15+
#
# Usage: ./scripts/build-xcframework.sh

SCRIPT_DIR="$(cd "$(dirname "$0")" && pwd)"
ROOT_DIR="$(cd "$SCRIPT_DIR/.." && pwd)"
IOS_PROJECT="$ROOT_DIR/sdk/ios/TagDataTranslation.iOS.csproj"
OUTPUT_DIR="$ROOT_DIR/artifacts/ios"
PUBLISH_BASE="$ROOT_DIR/sdk/ios/bin/Release/net10.0"

mkdir -p "$OUTPUT_DIR"

echo "=== Building TagDataTranslation for iOS arm64 ==="
dotnet publish "$IOS_PROJECT" -c Release -r ios-arm64

echo ""
echo "=== Building TagDataTranslation for iOS Simulator arm64 ==="
dotnet publish "$IOS_PROJECT" -c Release -r iossimulator-arm64

echo ""
echo "=== Creating XCFramework ==="
XCFRAMEWORK_PATH="$OUTPUT_DIR/TagDataTranslation.xcframework"
rm -rf "$XCFRAMEWORK_PATH"

xcodebuild -create-xcframework \
    -library "$PUBLISH_BASE/ios-arm64/publish/TagDataTranslation.iOS.a" \
    -headers "$ROOT_DIR/sdk/swift/Sources/TagDataTranslation/include" \
    -library "$PUBLISH_BASE/iossimulator-arm64/publish/TagDataTranslation.iOS.a" \
    -headers "$ROOT_DIR/sdk/swift/Sources/TagDataTranslation/include" \
    -output "$XCFRAMEWORK_PATH"

echo ""
echo "=== XCFramework created ==="
echo "Output: $XCFRAMEWORK_PATH"
echo ""
echo "To embed in Flutter plugin:"
echo "  cp -R $XCFRAMEWORK_PATH $ROOT_DIR/sdk/flutter/tag_data_translation/ios/Frameworks/"
echo ""
echo "To create a release zip:"
echo "  cd $OUTPUT_DIR && zip -r TagDataTranslation.xcframework.zip TagDataTranslation.xcframework"
