using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

#nullable enable

namespace TagDataTranslation.Tables;

/// <summary>
/// Provides static methods to load TDT 2.2 tables from JSON streams.
/// </summary>
public static class TableLoader
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    #region JSON Models for Deserialization

    private class TableJsonRoot<T> where T : class
    {
        [JsonPropertyName("tableID")]
        public string? TableID { get; set; }

        [JsonPropertyName("date")]
        public string? Date { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("columns")]
        public List<ColumnDef>? Columns { get; set; }

        [JsonPropertyName("rows")]
        public List<T>? Rows { get; set; }
    }

    private class ColumnDef
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("encodingIndicator")]
        public int? EncodingIndicator { get; set; }

        [JsonPropertyName("specSection")]
        public string? SpecSection { get; set; }
    }

    // Table F row - column IDs: a, b, c, d, e, f, g, h, i, j, k, l, m, n, o
    private class TableFRow
    {
        [JsonPropertyName("a")]
        public string? A { get; set; } // AI

        [JsonPropertyName("b")]
        public string? B { get; set; } // Comp1-format

        [JsonPropertyName("c")]
        public string? C { get; set; } // Comp1-specSection

        [JsonPropertyName("d")]
        public string? D { get; set; } // Comp1-fixedLengthChrs

        [JsonPropertyName("e")]
        public string? E { get; set; } // Comp1-fixedLengthBits

        [JsonPropertyName("f")]
        public string? F { get; set; } // Comp1-encodingIndicatorBits

        [JsonPropertyName("g")]
        public string? G { get; set; } // Comp1-lengthIndicatorBits

        [JsonPropertyName("h")]
        public string? H { get; set; } // Comp1-maxCharacters

        [JsonPropertyName("i")]
        public string? I { get; set; } // Comp2-format

        [JsonPropertyName("j")]
        public string? J { get; set; } // Comp2-specSection

        [JsonPropertyName("k")]
        public string? K { get; set; } // Comp2-fixedLengthChrs

        [JsonPropertyName("l")]
        public string? L { get; set; } // Comp2-fixedLengthBits

        [JsonPropertyName("m")]
        public string? M { get; set; } // Comp2-encodingIndicatorBits

        [JsonPropertyName("n")]
        public string? N { get; set; } // Comp2-lengthIndicatorBits

        [JsonPropertyName("o")]
        public string? O { get; set; } // Comp2-maxCharacters
    }

    // Table K row - column IDs: a, b, c
    private class TableKRow
    {
        [JsonPropertyName("a")]
        public string? A { get; set; } // Initial two digits

        [JsonPropertyName("b")]
        public string? B { get; set; } // GS1 AI key length

        [JsonPropertyName("c")]
        public string? C { get; set; } // Additional bits to read
    }

    // Table E row - column IDs: a, b, c, d, e, f, g
    private class TableERow
    {
        [JsonPropertyName("a")]
        public string? A { get; set; } // Encoding indicator (decimal)

        [JsonPropertyName("b")]
        public string? B { get; set; } // 3-bit Encoding indicator

        [JsonPropertyName("c")]
        public string? C { get; set; } // Encoding name

        [JsonPropertyName("d")]
        public string? D { get; set; } // Supported characters

        [JsonPropertyName("e")]
        public string? E { get; set; } // Efficiency

        [JsonPropertyName("f")]
        public string? F { get; set; } // Regex

        [JsonPropertyName("g")]
        public string? G { get; set; } // Spec Section
    }

    // Table B row - column IDs: a, b, c, d, e, f, g
    private class TableBRow
    {
        [JsonPropertyName("a")]
        public string? A { get; set; } // Length

        [JsonPropertyName("b")]
        public string? B { get; set; } // Variable-length integer (indicator 0)

        [JsonPropertyName("c")]
        public string? C { get; set; } // Upper case hex (indicator 1)

        [JsonPropertyName("d")]
        public string? D { get; set; } // Lower case hex (indicator 2)

        [JsonPropertyName("e")]
        public string? E { get; set; } // URN Code 40 (indicator 5)

        [JsonPropertyName("f")]
        public string? F { get; set; } // Base 64 (indicator 3)

        [JsonPropertyName("g")]
        public string? G { get; set; } // 7-bit ASCII (indicator 4)
    }

    #endregion

    /// <summary>
    /// Loads Table F from a JSON stream.
    /// </summary>
    /// <param name="stream">The JSON stream to read from.</param>
    /// <returns>The loaded TableF instance.</returns>
    public static TableF LoadTableF(Stream stream)
    {
        var root = JsonSerializer.Deserialize<TableJsonRoot<TableFRow>>(stream, JsonOptions)
            ?? throw new InvalidOperationException("Failed to deserialize Table F JSON");

        var table = new TableF();

        if (root.Rows != null)
        {
            foreach (var row in root.Rows)
            {
                if (string.IsNullOrEmpty(row.A)) continue;

                var entry = new TableFEntry
                {
                    AI = row.A,
                    Comp1Format = row.B,
                    Comp1SpecSection = row.C,
                    Comp1FixedLengthChars = ParseNullableInt(row.D),
                    Comp1FixedLengthBits = ParseNullableInt(row.E),
                    Comp1EncodingIndicatorBits = ParseNullableInt(row.F),
                    Comp1LengthIndicatorBits = ParseNullableInt(row.G),
                    Comp1MaxCharacters = ParseNullableInt(row.H),
                    Comp2Format = row.I,
                    Comp2SpecSection = row.J,
                    Comp2FixedLengthChars = ParseNullableInt(row.K),
                    Comp2FixedLengthBits = ParseNullableInt(row.L),
                    Comp2EncodingIndicatorBits = ParseNullableInt(row.M),
                    Comp2LengthIndicatorBits = ParseNullableInt(row.N),
                    Comp2MaxCharacters = ParseNullableInt(row.O)
                };

                table.AddEntry(entry);
            }
        }

        return table;
    }

    /// <summary>
    /// Loads Table K from a JSON stream.
    /// </summary>
    /// <param name="stream">The JSON stream to read from.</param>
    /// <returns>The loaded TableK instance.</returns>
    public static TableK LoadTableK(Stream stream)
    {
        var root = JsonSerializer.Deserialize<TableJsonRoot<TableKRow>>(stream, JsonOptions)
            ?? throw new InvalidOperationException("Failed to deserialize Table K JSON");

        var table = new TableK();

        if (root.Rows != null)
        {
            foreach (var row in root.Rows)
            {
                if (string.IsNullOrEmpty(row.A)) continue;

                var entry = new TableKEntry
                {
                    InitialTwoDigits = row.A,
                    AIKeyLength = ParseInt(row.B, 2),
                    AdditionalBitsToRead = ParseInt(row.C, 0)
                };

                table.AddEntry(entry);
            }
        }

        return table;
    }

    /// <summary>
    /// Loads Table E from a JSON stream.
    /// </summary>
    /// <param name="stream">The JSON stream to read from.</param>
    /// <returns>The loaded TableE instance.</returns>
    public static TableE LoadTableE(Stream stream)
    {
        var root = JsonSerializer.Deserialize<TableJsonRoot<TableERow>>(stream, JsonOptions)
            ?? throw new InvalidOperationException("Failed to deserialize Table E JSON");

        var table = new TableE();

        if (root.Rows != null)
        {
            foreach (var row in root.Rows)
            {
                var entry = new TableEEntry
                {
                    EncodingIndicator = ParseInt(row.A, 0),
                    BinaryIndicator = row.B,
                    Method = row.C,
                    CharacterSet = row.D,
                    Efficiency = row.E,
                    Regex = row.F,
                    SpecSection = row.G
                };

                table.AddEntry(entry);
            }
        }

        return table;
    }

    /// <summary>
    /// Loads Table B from a JSON stream.
    /// </summary>
    /// <param name="stream">The JSON stream to read from.</param>
    /// <returns>The loaded TableB instance.</returns>
    public static TableB LoadTableB(Stream stream)
    {
        var root = JsonSerializer.Deserialize<TableJsonRoot<TableBRow>>(stream, JsonOptions)
            ?? throw new InvalidOperationException("Failed to deserialize Table B JSON");

        var table = new TableB();

        if (root.Rows != null)
        {
            foreach (var row in root.Rows)
            {
                var entry = new TableBEntry
                {
                    Length = ParseInt(row.A, 0),
                    VariableLengthIntegerBits = ParseInt(row.B, 0),
                    UpperCaseHexBits = ParseInt(row.C, 0),
                    LowerCaseHexBits = ParseInt(row.D, 0),
                    UrnCode40Bits = ParseInt(row.E, 0),  // Column e is URN Code 40 (indicator 5)
                    Base64Bits = ParseInt(row.F, 0),     // Column f is Base 64 (indicator 3)
                    AsciiBits = ParseInt(row.G, 0)       // Column g is 7-bit ASCII (indicator 4)
                };

                table.AddEntry(entry);
            }
        }

        return table;
    }

    /// <summary>
    /// Loads Table F from a JSON string.
    /// </summary>
    /// <param name="json">The JSON string to parse.</param>
    /// <returns>The loaded TableF instance.</returns>
    public static TableF LoadTableFFromString(string json)
    {
        using var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(json));
        return LoadTableF(stream);
    }

    /// <summary>
    /// Loads Table K from a JSON string.
    /// </summary>
    /// <param name="json">The JSON string to parse.</param>
    /// <returns>The loaded TableK instance.</returns>
    public static TableK LoadTableKFromString(string json)
    {
        using var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(json));
        return LoadTableK(stream);
    }

    /// <summary>
    /// Loads Table E from a JSON string.
    /// </summary>
    /// <param name="json">The JSON string to parse.</param>
    /// <returns>The loaded TableE instance.</returns>
    public static TableE LoadTableEFromString(string json)
    {
        using var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(json));
        return LoadTableE(stream);
    }

    /// <summary>
    /// Loads Table B from a JSON string.
    /// </summary>
    /// <param name="json">The JSON string to parse.</param>
    /// <returns>The loaded TableB instance.</returns>
    public static TableB LoadTableBFromString(string json)
    {
        using var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(json));
        return LoadTableB(stream);
    }

    private static int? ParseNullableInt(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return null;

        return int.TryParse(value, out var result) ? result : null;
    }

    private static int ParseInt(string? value, int defaultValue)
    {
        if (string.IsNullOrWhiteSpace(value))
            return defaultValue;

        return int.TryParse(value, out var result) ? result : defaultValue;
    }
}
