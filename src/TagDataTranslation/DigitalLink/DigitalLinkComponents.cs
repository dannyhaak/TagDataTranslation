using System.Collections.Generic;

namespace TagDataTranslation.DigitalLink
{
    /// <summary>
    /// Represents the components of a GS1 Digital Link URI.
    /// </summary>
    public class DigitalLinkComponents
    {
        /// <summary>
        /// The domain of the Digital Link URI (e.g., "example.com").
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// AI 01 - Global Trade Item Number (GTIN).
        /// </summary>
        public string Gtin { get; set; }

        /// <summary>
        /// AI 21 - Serial Number.
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// AI 10 - Batch/Lot Number.
        /// </summary>
        public string BatchLot { get; set; }

        /// <summary>
        /// AI 17 - Expiration Date (YYMMDD format).
        /// </summary>
        public string ExpiryDate { get; set; }

        /// <summary>
        /// AI 22 - Consumer Product Variant (CPV).
        /// </summary>
        public string Cpv { get; set; }

        /// <summary>
        /// Dictionary containing any other Application Identifiers not explicitly modeled.
        /// Key is the AI code, value is the AI value.
        /// </summary>
        public Dictionary<string, string> OtherAIs { get; set; } = new Dictionary<string, string>();
    }
}
