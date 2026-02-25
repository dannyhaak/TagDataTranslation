# tag-data-translation

GS1 EPC Tag Data Translation for Python and RAIN (UHF) RFID. Encode and decode SGTIN, SSCC, SGLN, GRAI, and all EPC schemes defined in TDT 2.2 and TDS 2.3.

## Requirements

- Python 3.9+
- .NET 8.0+ runtime ([download](https://dotnet.microsoft.com/download))

## Installation

```bash
pip install tag-data-translation
```

## Usage

```python
from tag_data_translation import TDTEngine

engine = TDTEngine()

# encode GTIN to EPC hex
binary = engine.translate(
    "gtin=00037000302414;serial=10419703",
    "filter=1;gs1companyprefixlength=7;tagLength=96",
    "BINARY"
)
hex_value = engine.binary_to_hex(binary)
print(hex_value)  # 30340242201d8840009efdf7

# decode EPC hex to all fields
binary = engine.hex_to_binary("30340242201d8840009efdf7")
result = engine.translate_details(binary, "tagLength=96", "TAG_ENCODING")
print(result.output)   # urn:epc:tag:sgtin-96:1.0037000.030241.10419703
print(result.fields)   # {'filter': '1', 'gs1companyprefix': '0037000', ...}
```

## Error handling

`translate()` raises `TranslationError` on invalid input. Use `try_translate()` for a non-throwing alternative:

```python
from tag_data_translation import TDTEngine, TranslationError

engine = TDTEngine()

# raises on error
try:
    result = engine.translate(epc, params, "BINARY")
except TranslationError as e:
    print(f"Translation failed: {e}")

# returns None on error
result = engine.try_translate(epc, params, "BINARY")
if result is not None:
    print(result)
```

## Performance

The underlying .NET engine translates a typical SGTIN-96 in ~8 us. The pythonnet bridge adds minimal overhead on top of the native .NET performance.

| Operation | .NET native |
|-----------|-------------|
| SGTIN-96 encode | 7.8 us |
| SGTIN-96 decode | 7.7 us |
| HexToBinary (96-bit) | 99 ns |
| BinaryToHex (96-bit) | 54 ns |

## License

BSL 1.1 — see [LICENSING.md](https://github.com/dannyhaak/TagDataTranslation/blob/master/LICENSING.md)
