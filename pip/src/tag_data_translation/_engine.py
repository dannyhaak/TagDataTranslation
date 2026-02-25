"""pythonnet wrapper around the TagDataTranslation .NET library."""

from __future__ import annotations

import os
import sys
from pathlib import Path


class TranslationError(Exception):
    """Raised when an EPC translation fails."""

    def __init__(self, message: str, error_code: str | None = None):
        super().__init__(message)
        self.error_code = error_code


class TranslateResult:
    """Result of a detailed translation, including all parsed fields."""

    def __init__(self, output: str, fields: dict[str, str]):
        self.output = output
        self.fields = fields

    def __repr__(self) -> str:
        return f"TranslateResult(output={self.output!r}, fields={self.fields!r})"


def _ensure_runtime() -> None:
    """Load the CLR runtime and add a reference to the TagDataTranslation assembly."""
    global _clr_loaded
    if _clr_loaded:
        return

    # the compiled DLL ships inside the package at dotnet/
    dotnet_dir = str(Path(__file__).parent / "dotnet")
    if not os.path.isdir(dotnet_dir):
        raise FileNotFoundError(
            f"TagDataTranslation .NET assemblies not found at {dotnet_dir}. "
            "Run 'python -m pip install tag-data-translation' or build with scripts/build.py."
        )

    # pythonnet requires the runtime to be set before importing clr
    from pythonnet import load

    load("coreclr")

    import clr  # noqa: E402

    sys.path.insert(0, dotnet_dir)
    clr.AddReference("TagDataTranslation")

    _clr_loaded = True


_clr_loaded = False


def _extract_message(exc: Exception) -> str:
    """Extract the .NET exception message without the stack trace."""
    # pythonnet exceptions have a .Message property from System.Exception
    if hasattr(exc, "Message"):
        return str(exc.Message)
    msg = str(exc)
    # strip everything after the first newline (stack trace)
    return msg.split("\n")[0].strip()


class TDTEngine:
    """GS1 EPC Tag Data Translation engine.

    Wraps the .NET TDTEngine via pythonnet, providing encode/decode
    for all EPC schemes defined in TDT 2.2 and TDS 2.3.

    Requires .NET 8.0+ runtime installed on the system.
    """

    def __init__(self) -> None:
        _ensure_runtime()

        from TagDataTranslation import TDTEngine as DotNetTDTEngine  # type: ignore[import]

        self._engine = DotNetTDTEngine()

    @property
    def load_errors(self) -> list[str]:
        """Errors encountered while loading scheme files, if any."""
        errors = self._engine.LoadErrors
        if errors is None:
            return []
        return [str(e) for e in errors]

    def translate(self, epc_identifier: str, parameter_list: str, output_format: str) -> str:
        """Translate an EPC identifier to the requested output format.

        Args:
            epc_identifier: The input EPC value (hex, URI, element string, etc.)
            parameter_list: Semicolon-separated parameters (e.g. "tagLength=96")
            output_format: Target format (BINARY, TAG_ENCODING, PURE_IDENTITY, etc.)

        Returns:
            The translated EPC string.

        Raises:
            TranslationError: If the translation fails.
        """
        try:
            return str(self._engine.Translate(epc_identifier, parameter_list, output_format))
        except Exception as e:
            raise TranslationError(_extract_message(e)) from e

    def try_translate(self, epc_identifier: str, parameter_list: str, output_format: str) -> str | None:
        """Translate an EPC identifier, returning None on failure.

        Same as translate() but returns None instead of raising.
        """
        from System import String  # type: ignore[import]

        success, result, error_code = self._engine.TryTranslate(
            epc_identifier, parameter_list, output_format,
            String(""), String(""),
        )
        if success:
            return str(result)
        return None

    def translate_details(self, epc_identifier: str, parameter_list: str, output_format: str) -> TranslateResult:
        """Translate and return detailed results including all parsed fields.

        Args:
            epc_identifier: The input EPC value.
            parameter_list: Semicolon-separated parameters.
            output_format: Target format.

        Returns:
            TranslateResult with .output and .fields dict.

        Raises:
            TranslationError: If the translation fails.
        """
        try:
            dotnet_result = self._engine.TranslateDetails(epc_identifier, parameter_list, output_format)
            fields = {}
            if dotnet_result.ParameterDictionary is not None:
                for key in dotnet_result.ParameterDictionary.Keys:
                    fields[str(key)] = str(dotnet_result.ParameterDictionary[key])
            return TranslateResult(output=str(dotnet_result.Output), fields=fields)
        except Exception as e:
            raise TranslationError(_extract_message(e)) from e

    def try_translate_details(self, epc_identifier: str, parameter_list: str, output_format: str) -> TranslateResult | None:
        """Translate with details, returning None on failure."""
        from System import String  # type: ignore[import]
        from TagDataTranslation import TranslateResult as DotNetTranslateResult  # type: ignore[import]

        success, dotnet_result, error_code = self._engine.TryTranslateDetails(
            epc_identifier, parameter_list, output_format,
            DotNetTranslateResult(), String(""),
        )
        if not success:
            return None
        fields = {}
        if dotnet_result.ParameterDictionary is not None:
            for key in dotnet_result.ParameterDictionary.Keys:
                fields[str(key)] = str(dotnet_result.ParameterDictionary[key])
        return TranslateResult(output=str(dotnet_result.Output), fields=fields)

    def hex_to_binary(self, hex_value: str) -> str:
        """Convert a hexadecimal EPC to binary string."""
        return str(self._engine.HexToBinary(hex_value))

    def binary_to_hex(self, binary: str) -> str:
        """Convert a binary EPC string to hexadecimal."""
        return str(self._engine.BinaryToHex(binary))
