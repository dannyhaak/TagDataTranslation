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
            url: "https://github.com/dannyhaak/TagDataTranslation/releases/download/v3.0.6/TagDataTranslation.xcframework.zip",
            checksum: "7c34dc5938b2ca0028710c06803b18c9eec3acdd87d9049aca778ec08a06030a"
        )
    ]
)
