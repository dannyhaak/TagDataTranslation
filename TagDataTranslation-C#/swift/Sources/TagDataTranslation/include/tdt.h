#ifndef TDT_H
#define TDT_H

#include <stdint.h>

/// Translate an EPC identifier between encoding levels.
/// Returns a UTF-8 string that must be freed with tdt_free_string().
/// On error, returns "ERROR:<message>".
const char* tdt_translate(const char* epcIdentifier, const char* parameterList, const char* outputFormat);

/// Translate without exceptions. Returns NULL on failure.
/// Result must be freed with tdt_free_string().
const char* tdt_try_translate(const char* epcIdentifier, const char* parameterList, const char* outputFormat);

/// Convert hex string to binary string.
/// Result must be freed with tdt_free_string().
const char* tdt_hex_to_binary(const char* hex);

/// Convert binary string to hex string.
/// Result must be freed with tdt_free_string().
const char* tdt_binary_to_hex(const char* binary);

/// Free a string returned by tdt_* functions.
void tdt_free_string(const char* ptr);

#endif
