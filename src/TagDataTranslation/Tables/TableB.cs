using System.Collections.Generic;

#nullable enable

namespace TagDataTranslation.Tables;

/// <summary>
/// Represents an entry in Table B - Number of bits required depending on encoding scheme and number of characters.
/// </summary>
public class TableBEntry
{
    /// <summary>
    /// Number of digits or characters.
    /// </summary>
    public int Length { get; set; }

    /// <summary>
    /// Bits required for Variable-length integer encoding (encoding indicator 0).
    /// </summary>
    public int VariableLengthIntegerBits { get; set; }

    /// <summary>
    /// Bits required for Variable-length upper case hexadecimal encoding (encoding indicator 1).
    /// </summary>
    public int UpperCaseHexBits { get; set; }

    /// <summary>
    /// Bits required for Variable-length lower case hexadecimal encoding (encoding indicator 2).
    /// </summary>
    public int LowerCaseHexBits { get; set; }

    /// <summary>
    /// Bits required for Variable-length filesafe URI-safe base 64 encoding (encoding indicator 3).
    /// </summary>
    public int Base64Bits { get; set; }

    /// <summary>
    /// Bits required for Variable-length 7-bit ASCII encoding (encoding indicator 4).
    /// </summary>
    public int AsciiBits { get; set; }

    /// <summary>
    /// Bits required for Variable-length URN Code 40 encoding (encoding indicator 5).
    /// </summary>
    public int UrnCode40Bits { get; set; }
}

/// <summary>
/// Table B - Number of bits required depending on encoding scheme and number of characters or digits to be encoded.
/// </summary>
public class TableB
{
    private readonly Dictionary<int, TableBEntry> _entriesByLength = new();
    private readonly Dictionary<(int, int), int> _bitCounts = new();

    /// <summary>
    /// Gets the entry for the specified character/digit count.
    /// </summary>
    /// <param name="length">The number of characters or digits.</param>
    /// <returns>The table entry if found; otherwise, null.</returns>
    public TableBEntry? GetEntry(int length) =>
        _entriesByLength.TryGetValue(length, out var entry) ? entry : null;

    /// <summary>
    /// Gets the bit count for the specified character count and encoding indicator.
    /// </summary>
    /// <param name="charCount">The number of characters to encode.</param>
    /// <param name="encodingIndicator">The encoding indicator (0-5).</param>
    /// <returns>The number of bits required; 0 if not found.</returns>
    public int GetBitCount(int charCount, int encodingIndicator) =>
        _bitCounts.TryGetValue((charCount, encodingIndicator), out var bits) ? bits : 0;

    /// <summary>
    /// Gets the bit count for the specified character count and encoding method name.
    /// </summary>
    /// <param name="charCount">The number of characters to encode.</param>
    /// <param name="method">The encoding method name.</param>
    /// <returns>The number of bits required; 0 if not found.</returns>
    public int GetBitCount(int charCount, string method)
    {
        // Map method names to encoding indicators
        var indicator = method switch
        {
            "Variable-length integer" => 0,
            "Variable-length upper case hexadecimal" => 1,
            "Variable-length lower case hexadecimal" => 2,
            "Variable-length filesafe URI-safe base 64 (see RFC 4648 section 5)" => 3,
            "Variable-length 7-bit ASCII" => 4,
            "Variable-length URN Code 40" => 5,
            _ => -1
        };

        return indicator >= 0 ? GetBitCount(charCount, indicator) : 0;
    }

    /// <summary>
    /// Adds an entry to the table.
    /// </summary>
    /// <param name="entry">The entry to add.</param>
    internal void AddEntry(TableBEntry entry)
    {
        _entriesByLength[entry.Length] = entry;

        // Populate the bit count lookup
        _bitCounts[(entry.Length, 0)] = entry.VariableLengthIntegerBits;
        _bitCounts[(entry.Length, 1)] = entry.UpperCaseHexBits;
        _bitCounts[(entry.Length, 2)] = entry.LowerCaseHexBits;
        _bitCounts[(entry.Length, 3)] = entry.Base64Bits;
        _bitCounts[(entry.Length, 4)] = entry.AsciiBits;
        _bitCounts[(entry.Length, 5)] = entry.UrnCode40Bits;
    }

    /// <summary>
    /// Gets the number of entries in the table.
    /// </summary>
    public int Count => _entriesByLength.Count;

    /// <summary>
    /// Gets all entries in the table.
    /// </summary>
    public IEnumerable<TableBEntry> Entries => _entriesByLength.Values;
}
