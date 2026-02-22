// swift-tools-version: 5.9
import PackageDescription

let package = Package(
    name: "TagDataTranslation",
    platforms: [
        .iOS(.v15),
        .macCatalyst(.v15)
    ],
    products: [
        .library(
            name: "TagDataTranslation",
            targets: ["TagDataTranslation", "TagDataTranslationBinary"]
        )
    ],
    targets: [
        .target(
            name: "TagDataTranslation",
            dependencies: ["TagDataTranslationBinary"],
            path: "Sources/TagDataTranslation",
            exclude: ["include"]
        ),
        // The prebuilt XCFramework -- updated on each release
        .binaryTarget(
            name: "TagDataTranslationBinary",
            // TODO: Update URL and checksum for each release
            url: "https://github.com/dannyhaak/TagDataTranslation/releases/download/v3.0.0/TagDataTranslation.xcframework.zip",
            checksum: "PLACEHOLDER_CHECKSUM"
        )
    ]
)
