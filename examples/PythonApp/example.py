"""TagDataTranslation Python example.

Prerequisites:
  1. Install .NET 8.0+ runtime
  2. Build: cd ../../pip && python scripts/build.py
  3. Install: cd ../../pip && pip install -e .
  4. Run: python example.py
"""

from tag_data_translation import TDTEngine, TranslationError

def main():
    print("=== TagDataTranslation Python Example ===\n")
    print("Loading engine...")

    engine = TDTEngine()

    # check for scheme load errors
    errors = engine.load_errors
    if errors:
        print(f"Scheme load errors: {errors}")

    # decode: hex -> all representations
    hex_value = "30340242201d8840009efdf7"
    binary = engine.hex_to_binary(hex_value)

    print(f"\nDecode hex to all formats:")
    print(f"  Hex:           {hex_value}")
    print(f"  Binary:        {binary[:32]}...")

    pure_identity = engine.translate(binary, "tagLength=96", "PURE_IDENTITY")
    print(f"  Pure Identity: {pure_identity}")

    tag_uri = engine.translate(binary, "tagLength=96", "TAG_ENCODING")
    print(f"  Tag URI:       {tag_uri}")

    # encode: GTIN + serial -> binary -> hex
    print(f"\nEncode GTIN to hex:")
    input_value = "gtin=00037000302414;serial=10419703"
    params = "filter=1;gs1companyprefixlength=7;tagLength=96"
    encoded_binary = engine.translate(input_value, params, "BINARY")
    encoded_hex = engine.binary_to_hex(encoded_binary)
    print(f"  Input:  {input_value}")
    print(f"  Hex:    {encoded_hex}")

    # detailed translation with fields
    print(f"\nDetailed translation:")
    result = engine.translate_details(binary, "tagLength=96", "TAG_ENCODING")
    print(f"  Output: {result.output}")
    print(f"  Fields: {result.fields}")

    # exception-free translation
    print(f"\nTryTranslate with invalid input:")
    result = engine.try_translate("invalid-input", "", "BINARY")
    print(f"  Result: {'None (translation failed gracefully)' if result is None else result}")

    # error handling
    print(f"\nError handling:")
    try:
        engine.translate("invalid-input", "", "BINARY")
    except TranslationError as e:
        print(f"  Caught TranslationError: {e}")

    print("\nDone.")


if __name__ == "__main__":
    main()
