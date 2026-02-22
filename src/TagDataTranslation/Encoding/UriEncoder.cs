using System;
using System.Collections.Generic;
using System.Text;

namespace TagDataTranslation.Encoding;

/// <summary>
/// Provides URL and URN encoding/decoding functionality for GS1 EPC identifiers.
/// URN encoding is used for Pure Identity and Tag Encoding URIs.
/// URL encoding is used for GS1 Digital Link URIs.
/// </summary>
public static class UriEncoder
{
    /// <summary>
    /// Characters that must be percent-encoded in URN format.
    /// Note: The order matters - '%' is first to ensure it's encoded before other characters
    /// that would introduce '%' in their encoded form.
    /// </summary>
    private static readonly Dictionary<char, string> UrnEncodeMap = new()
    {
        { '%', "%25" },  // Must be first when encoding
        { '"', "%22" },
        { '&', "%26" },
        { '/', "%2F" },
        { '<', "%3C" },
        { '>', "%3E" },
        { '?', "%3F" },
        { '#', "%23" }
    };

    /// <summary>
    /// Reverse mapping for URN decoding.
    /// Note: '%25' (percent) is decoded last to avoid corrupting other encoded sequences.
    /// </summary>
    private static readonly List<(char Character, string Encoded)> UrnDecodeList = new()
    {
        ('"', "%22"),
        ('&', "%26"),
        ('/', "%2F"),
        ('<', "%3C"),
        ('>', "%3E"),
        ('?', "%3F"),
        ('#', "%23"),
        ('%', "%25")  // Must be last when decoding
    };

    /// <summary>
    /// Encodes a string for use in a URN (Uniform Resource Name).
    /// Special characters are percent-encoded according to GS1 TDT specifications.
    /// </summary>
    /// <param name="input">The string to encode.</param>
    /// <returns>The URN-encoded string.</returns>
    public static string UrnEncode(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        var sb = new StringBuilder(input.Length * 2);
        foreach (var c in input)
        {
            if (UrnEncodeMap.TryGetValue(c, out var encoded))
            {
                sb.Append(encoded);
            }
            else
            {
                sb.Append(c);
            }
        }
        return sb.ToString();
    }

    /// <summary>
    /// Decodes a URN-encoded string back to its original form.
    /// Percent-encoded sequences are decoded according to GS1 TDT specifications.
    /// </summary>
    /// <param name="input">The URN-encoded string to decode.</param>
    /// <returns>The decoded string.</returns>
    public static string UrnDecode(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        var result = input;
        // Decode all characters except '%' first, then decode '%' last
        // to avoid double-decoding issues (e.g., %2525 -> %25 -> %)
        foreach (var (character, encoded) in UrnDecodeList)
        {
            result = result.Replace(encoded, character.ToString());
        }
        return result;
    }

    /// <summary>
    /// Encodes a string for use in a URL (GS1 Digital Link).
    /// Uses standard percent-encoding as defined in RFC 3986.
    /// </summary>
    /// <param name="input">The string to encode.</param>
    /// <returns>The URL-encoded string.</returns>
    public static string UrlEncode(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        return Uri.EscapeDataString(input);
    }

    /// <summary>
    /// Decodes a URL-encoded string back to its original form.
    /// Percent-encoded sequences are decoded according to RFC 3986.
    /// </summary>
    /// <param name="input">The URL-encoded string to decode.</param>
    /// <returns>The decoded string.</returns>
    public static string UrlDecode(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        return Uri.UnescapeDataString(input);
    }
}
