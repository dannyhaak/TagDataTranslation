using System.Collections.Generic;

#nullable enable

namespace TagDataTranslation.Tables;

/// <summary>
/// Represents an entry in Table K - Length of GS1 Application Identifier key based on initial two digits.
/// </summary>
public class TableKEntry
{
    /// <summary>
    /// Initial two digits of a GS1 Application Identifier key.
    /// </summary>
    public string InitialTwoDigits { get; set; } = string.Empty;

    /// <summary>
    /// Length of the GS1 Application Identifier key (2, 3 or 4 digits).
    /// </summary>
    public int AIKeyLength { get; set; }

    /// <summary>
    /// Number of additional bits to read beyond the initial 8 bits of the data header.
    /// </summary>
    public int AdditionalBitsToRead { get; set; }
}

/// <summary>
/// Table K - Length of GS1 Application Identifier key based on initial two digits.
/// Based on GS1 Gen Specs Figure 7.8.2-1 GS1 Application Identifier lengths.
/// </summary>
public class TableK
{
    private readonly Dictionary<string, TableKEntry> _entries = new();

    /// <summary>
    /// Gets the entry for the specified AI prefix (first two digits).
    /// </summary>
    /// <param name="aiPrefix">The first two digits of the AI.</param>
    /// <returns>The table entry if found; otherwise, null.</returns>
    public TableKEntry? GetEntry(string aiPrefix) =>
        _entries.TryGetValue(aiPrefix, out var entry) ? entry : null;

    /// <summary>
    /// Gets the key length for the specified AI prefix (first two digits).
    /// Returns 2 as the default if not found.
    /// </summary>
    /// <param name="aiPrefix">The first two digits of the AI.</param>
    /// <returns>The key length (2, 3, or 4 digits).</returns>
    public int GetKeyLength(string aiPrefix) =>
        _entries.TryGetValue(aiPrefix, out var entry) ? entry.AIKeyLength : 2;

    /// <summary>
    /// Gets the number of additional bits to read for the specified AI prefix.
    /// Returns 0 as the default if not found.
    /// </summary>
    /// <param name="aiPrefix">The first two digits of the AI.</param>
    /// <returns>The number of additional bits to read.</returns>
    public int GetAdditionalBits(string aiPrefix) =>
        _entries.TryGetValue(aiPrefix, out var entry) ? entry.AdditionalBitsToRead : 0;

    /// <summary>
    /// Adds an entry to the table.
    /// </summary>
    /// <param name="entry">The entry to add.</param>
    internal void AddEntry(TableKEntry entry)
    {
        _entries[entry.InitialTwoDigits] = entry;
    }

    /// <summary>
    /// Gets the number of entries in the table.
    /// </summary>
    public int Count => _entries.Count;

    /// <summary>
    /// Gets all entries in the table.
    /// </summary>
    public IEnumerable<TableKEntry> Entries => _entries.Values;
}
