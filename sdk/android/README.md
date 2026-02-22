# TagDataTranslation Android SDK

Native Android library for GS1 EPC Tag Data Translation, built with .NET for Android.

## Status

This project is a scaffold for the native Android SDK. It compiles the TagDataTranslation
library into a .NET Android class library with Java-callable wrappers, making it usable
from Kotlin and Java code.

## Building

```bash
dotnet build TagDataTranslation.Android/TagDataTranslation.Android.csproj
```

## Maven Central

The planned Maven coordinates are:

```kotlin
implementation("nl.mimasu:tag-data-translation:3.0.0")
```

## Kotlin Usage

```kotlin
import nl.mimasu.tdt.TDTEngine

val engine = TDTEngine()
val binary = engine.hexToBinary("30340242201d8840009efdf7")
val uri = engine.translate(binary, "tagLength=96", "PURE_IDENTITY")
// urn:epc:id:sgtin:0037000.030241.10419703
```

## License

Business Source License 1.1. Production use requires a commercial license -- contact tdt@mimasu.nl.
