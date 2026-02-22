using System.Collections.Generic;

#nullable enable

namespace TagDataTranslation.Tables;

/// <summary>
/// Represents an entry in Table F - Encoding format table for values of GS1 Application Identifiers.
/// Maps GS1 Application Identifiers to their encoding format.
/// </summary>
public class TableFEntry
{
    /// <summary>
    /// GS1 Application Identifier key.
    /// </summary>
    public string AI { get; set; } = string.Empty;

    /// <summary>
    /// Format of first component (e.g., "Fixed-length numeric", "Variable-length alphanumeric").
    /// </summary>
    public string? Comp1Format { get; set; }

    /// <summary>
    /// Section of TDS 2.0 for encoding of first component.
    /// </summary>
    public string? Comp1SpecSection { get; set; }

    /// <summary>
    /// Number of characters Fixed Length for first component.
    /// </summary>
    public int? Comp1FixedLengthChars { get; set; }

    /// <summary>
    /// Number of bits Fixed Length for first component.
    /// </summary>
    public int? Comp1FixedLengthBits { get; set; }

    /// <summary>
    /// Number of bits for encoding indicator of first component.
    /// </summary>
    public int? Comp1EncodingIndicatorBits { get; set; }

    /// <summary>
    /// Number of bits for length indicator of first component.
    /// </summary>
    public int? Comp1LengthIndicatorBits { get; set; }

    /// <summary>
    /// Maximum length (characters) for first component.
    /// </summary>
    public int? Comp1MaxCharacters { get; set; }

    /// <summary>
    /// Format of second component (for two-component AIs like 253, 255).
    /// </summary>
    public string? Comp2Format { get; set; }

    /// <summary>
    /// Section of TDS 2.0 for encoding of second component.
    /// </summary>
    public string? Comp2SpecSection { get; set; }

    /// <summary>
    /// Number of characters Fixed Length for second component.
    /// </summary>
    public int? Comp2FixedLengthChars { get; set; }

    /// <summary>
    /// Number of bits Fixed Length for second component.
    /// </summary>
    public int? Comp2FixedLengthBits { get; set; }

    /// <summary>
    /// Number of bits for encoding indicator of second component.
    /// </summary>
    public int? Comp2EncodingIndicatorBits { get; set; }

    /// <summary>
    /// Number of bits for length indicator of second component.
    /// </summary>
    public int? Comp2LengthIndicatorBits { get; set; }

    /// <summary>
    /// Maximum length (characters) for second component.
    /// </summary>
    public int? Comp2MaxCharacters { get; set; }

    /// <summary>
    /// Returns true if this AI has a second component.
    /// </summary>
    public bool HasSecondComponent => !string.IsNullOrEmpty(Comp2Format);
}

/// <summary>
/// Table F - Encoding format table for values of GS1 Application Identifiers.
/// </summary>
public class TableF
{
    private readonly Dictionary<string, TableFEntry> _entries = new();

    /// <summary>
    /// Gets the table entry for the specified Application Identifier.
    /// </summary>
    /// <param name="ai">The GS1 Application Identifier.</param>
    /// <returns>The table entry if found; otherwise, null.</returns>
    public TableFEntry? GetEntry(string ai) =>
        _entries.TryGetValue(ai, out var entry) ? entry : null;

    /// <summary>
    /// Adds an entry to the table.
    /// </summary>
    /// <param name="entry">The entry to add.</param>
    internal void AddEntry(TableFEntry entry)
    {
        _entries[entry.AI] = entry;
    }

    /// <summary>
    /// Gets the number of entries in the table.
    /// </summary>
    public int Count => _entries.Count;

    /// <summary>
    /// Gets all entries in the table.
    /// </summary>
    public IEnumerable<TableFEntry> Entries => _entries.Values;
}
