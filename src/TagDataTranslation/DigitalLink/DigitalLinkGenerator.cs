using System;
using System.Collections.Generic;
using System.Text;

namespace TagDataTranslation.DigitalLink
{
    /// <summary>
    /// Generator for GS1 Digital Link URIs.
    /// Creates URIs like https://example.com/01/09521207311511/21/XYZ123
    /// </summary>
    public static class DigitalLinkGenerator
    {
        private const string DefaultScheme = "https";

        /// <summary>
        /// Generates a GS1 Digital Link URI from the provided components.
        /// </summary>
        /// <param name="components">The components to include in the URI.</param>
        /// <returns>A properly formatted GS1 Digital Link URI string.</returns>
        /// <exception cref="ArgumentNullException">Thrown when components is null.</exception>
        /// <exception cref="ArgumentException">Thrown when required components are missing.</exception>
        public static string Generate(DigitalLinkComponents components)
        {
            if (components == null)
            {
                throw new ArgumentNullException(nameof(components), "Components cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(components.Domain))
            {
                throw new ArgumentException("Domain is required.", nameof(components));
            }

            if (string.IsNullOrWhiteSpace(components.Gtin))
            {
                throw new ArgumentException("GTIN (AI 01) is required.", nameof(components));
            }

            var builder = new StringBuilder();

            // Build the base URL with scheme and domain
            builder.Append(DefaultScheme);
            builder.Append("://");
            builder.Append(components.Domain);

            // Add GTIN as primary identifier (always first in path)
            builder.Append("/01/");
            builder.Append(Uri.EscapeDataString(components.Gtin));

            // Add qualifiers in the path (21=Serial, 10=Batch, 22=CPV)
            if (!string.IsNullOrEmpty(components.SerialNumber))
            {
                builder.Append("/21/");
                builder.Append(Uri.EscapeDataString(components.SerialNumber));
            }

            if (!string.IsNullOrEmpty(components.BatchLot))
            {
                builder.Append("/10/");
                builder.Append(Uri.EscapeDataString(components.BatchLot));
            }

            if (!string.IsNullOrEmpty(components.Cpv))
            {
                builder.Append("/22/");
                builder.Append(Uri.EscapeDataString(components.Cpv));
            }

            // Build query string for attributes (17=Expiry and other AIs)
            var queryParams = new List<string>();

            if (!string.IsNullOrEmpty(components.ExpiryDate))
            {
                queryParams.Add($"17={Uri.EscapeDataString(components.ExpiryDate)}");
            }

            // Add any other AIs to the query string
            if (components.OtherAIs != null)
            {
                foreach (var kvp in components.OtherAIs)
                {
                    if (!string.IsNullOrEmpty(kvp.Value))
                    {
                        queryParams.Add($"{kvp.Key}={Uri.EscapeDataString(kvp.Value)}");
                    }
                }
            }

            // Append query string if there are any parameters
            if (queryParams.Count > 0)
            {
                builder.Append("?");
                builder.Append(string.Join("&", queryParams));
            }

            return builder.ToString();
        }

        /// <summary>
        /// Generates a GS1 Digital Link URI with a custom scheme (http or https).
        /// </summary>
        /// <param name="components">The components to include in the URI.</param>
        /// <param name="useHttps">Whether to use HTTPS (true) or HTTP (false).</param>
        /// <returns>A properly formatted GS1 Digital Link URI string.</returns>
        public static string Generate(DigitalLinkComponents components, bool useHttps)
        {
            var uri = Generate(components);

            if (!useHttps)
            {
                return uri.Replace("https://", "http://");
            }

            return uri;
        }
    }
}
