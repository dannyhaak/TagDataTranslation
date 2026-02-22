# TagDataTranslation iOS SDK

Native iOS framework for GS1 EPC Tag Data Translation, built with .NET NativeAOT.

## Status

This project is a scaffold for the native iOS SDK. It compiles the TagDataTranslation
library to a native static library via NativeAOT, producing C-callable symbols that
are wrapped by a Swift API.

## Building

```bash
# Build XCFramework (requires Mac with Xcode)
./scripts/build-xcframework.sh
```

## Swift Package Manager

```swift
dependencies: [
    .package(url: "https://github.com/dannyhaak/TagDataTranslation.git", from: "3.0.0")
]
```

## CocoaPods

```ruby
pod 'TagDataTranslation', '~> 3.0'
```

## Swift Usage

```swift
import TagDataTranslation

let engine = TDTEngine()
let binary = TDTEngine.hexToBinary("30340242201d8840009efdf7")
let uri = try engine.translate(binary, to: "PURE_IDENTITY", params: "tagLength=96")
// urn:epc:id:sgtin:0037000.030241.10419703
```

## License

Business Source License 1.1. Production use requires a commercial license -- contact tdt@mimasu.nl.
