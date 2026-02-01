using System.Collections.Generic;
using System.Linq;

#nullable enable

namespace TagDataTranslation.Tables;

/// <summary>
/// Represents an entry in Table E - Details of encoding schemes supported in TDS 2.0.
/// </summary>
public class TableEEntry
{
    /// <summary>
    /// Encoding indicator value (decimal integer).
    /// </summary>
    public int EncodingIndicator { get; set; }

    /// <summary>
    /// Encoding indicator value as 3-bit binary string.
    /// </summary>
    public string? BinaryIndicator { get; set; }

    /// <summary>
    /// Name of encoding method (e.g., "Variable-length integer", "Variable-length upper case hexadecimal").
    /// </summary>
    public string? Method { get; set; }

    /// <summary>
    /// Characters supported in this encoding.
    /// </summary>
    public string? CharacterSet { get; set; }

    /// <summary>
    /// Efficiency of encoding (bits per character).
    /// </summary>
    public string? Efficiency { get; set; }

    /// <summary>
    /// Regular expression for supported characters.
    /// </summary>
    public string? Regex { get; set; }

    /// <summary>
    /// Section of the TDS 2.0 standard explaining this encoding.
    /// </summary>
    public string? SpecSection { get; set; }
}

/// <summary>
/// Table E - Details of encoding schemes supported in TDS 2.0.
/// </summary>
public class TableE
{
    private readonly List<TableEEntry> _entries = new();

    /// <summary>
    /// Gets the entry for the specified encoding indicator value.
    /// </summary>
    /// <param name="indicator">The encoding indicator (0-5).</param>
    /// <returns>The table entry if found; otherwise, null.</returns>
    public TableEEntry? GetEntry(int indicator) =>
        _entries.FirstOrDefault(e => e.EncodingIndicator == indicator);

    /// <summary>
    /// Gets the entry for the specified encoding method name.
    /// </summary>
    /// <param name="method">The encoding method name.</param>
    /// <returns>The table entry if found; otherwise, null.</returns>
    public TableEEntry? GetEntryByMethod(string method) =>
        _entries.FirstOrDefault(e => e.Method == method);

    /// <summary>
    /// Adds an entry to the table.
    /// </summary>
    /// <param name="entry">The entry to add.</param>
    internal void AddEntry(TableEEntry entry)
    {
        _entries.Add(entry);
    }

    /// <summary>
    /// Gets the number of entries in the table.
    /// </summary>
    public int Count => _entries.Count;

    /// <summary>
    /// Gets all entries in the table.
    /// </summary>
    public IEnumerable<TableEEntry> Entries => _entries;
}
