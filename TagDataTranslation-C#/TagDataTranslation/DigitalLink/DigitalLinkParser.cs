using System;
using System.Collections.Generic;

namespace TagDataTranslation.DigitalLink
{
    /// <summary>
    /// Parser for GS1 Digital Link URIs.
    /// Parses URIs like https://example.com/01/09521207311511/21/XYZ123
    /// </summary>
    public static class DigitalLinkParser
    {
        // Known Application Identifiers for path segments (primary key and qualifiers)
        private static readonly HashSet<string> KnownPathAIs = new HashSet<string>
        {
            "01", // GTIN
            "21", // Serial Number
            "10", // Batch/Lot
            "22"  // CPV
        };

        // Known Application Identifiers for query string (attributes)
        private static readonly HashSet<string> KnownQueryAIs = new HashSet<string>
        {
            "17"  // Expiry Date
        };

        /// <summary>
        /// Parses a GS1 Digital Link URI into its component parts.
        /// </summary>
        /// <param name="uri">The Digital Link URI to parse.</param>
        /// <returns>A DigitalLinkComponents object containing the parsed values.</returns>
        /// <exception cref="ArgumentNullException">Thrown when uri is null or empty.</exception>
        /// <exception cref="ArgumentException">Thrown when the URI format is invalid.</exception>
        public static DigitalLinkComponents Parse(string uri)
        {
            if (string.IsNullOrWhiteSpace(uri))
            {
                throw new ArgumentNullException(nameof(uri), "URI cannot be null or empty.");
            }

            var components = new DigitalLinkComponents();

            // Parse the URI
            Uri parsedUri;
            try
            {
                parsedUri = new Uri(uri);
            }
            catch (UriFormatException ex)
            {
                throw new ArgumentException($"Invalid URI format: {uri}", nameof(uri), ex);
            }

            // Extract domain
            components.Domain = parsedUri.Host;

            // Parse path segments (AI/value pairs)
            ParsePathSegments(parsedUri.AbsolutePath, components);

            // Parse query string (AI=value pairs)
            if (!string.IsNullOrEmpty(parsedUri.Query))
            {
                ParseQueryString(parsedUri.Query, components);
            }

            return components;
        }

        /// <summary>
        /// Attempts to parse a GS1 Digital Link URI without throwing exceptions.
        /// </summary>
        /// <param name="uri">The Digital Link URI to parse.</param>
        /// <param name="components">The parsed components if successful.</param>
        /// <returns>True if parsing succeeded, false otherwise.</returns>
        public static bool TryParse(string uri, out DigitalLinkComponents components)
        {
            components = null;

            try
            {
                components = Parse(uri);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static void ParsePathSegments(string path, DigitalLinkComponents components)
        {
            // Remove leading slash and split by /
            var trimmedPath = path.TrimStart('/');
            if (string.IsNullOrEmpty(trimmedPath))
            {
                return;
            }

            var segments = trimmedPath.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            // Process pairs of AI/value
            for (int i = 0; i < segments.Length - 1; i += 2)
            {
                var ai = segments[i];
                var value = Uri.UnescapeDataString(segments[i + 1]);

                AssignAIValue(ai, value, components);
            }
        }

        private static void ParseQueryString(string query, DigitalLinkComponents components)
        {
            // Remove leading ? if present
            var trimmedQuery = query.TrimStart('?');
            if (string.IsNullOrEmpty(trimmedQuery))
            {
                return;
            }

            var pairs = trimmedQuery.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var pair in pairs)
            {
                var keyValue = pair.Split(new[] { '=' }, 2);
                if (keyValue.Length == 2)
                {
                    var ai = keyValue[0];
                    var value = Uri.UnescapeDataString(keyValue[1]);

                    AssignAIValue(ai, value, components);
                }
            }
        }

        private static void AssignAIValue(string ai, string value, DigitalLinkComponents components)
        {
            switch (ai)
            {
                case "01":
                    components.Gtin = value;
                    break;
                case "21":
                    components.SerialNumber = value;
                    break;
                case "10":
                    components.BatchLot = value;
                    break;
                case "17":
                    components.ExpiryDate = value;
                    break;
                case "22":
                    components.Cpv = value;
                    break;
                default:
                    components.OtherAIs[ai] = value;
                    break;
            }
        }
    }
}
