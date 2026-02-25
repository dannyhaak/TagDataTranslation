"""GS1 EPC Tag Data Translation for Python.

Wraps the TagDataTranslation .NET library via pythonnet, providing
encode/decode for all EPC schemes (SGTIN, SSCC, SGLN, GRAI, etc.).
"""

from tag_data_translation._engine import TDTEngine, TranslationError

__all__ = ["TDTEngine", "TranslationError"]
