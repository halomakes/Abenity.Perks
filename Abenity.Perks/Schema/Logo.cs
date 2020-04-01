using System;

namespace Abenity.Perks.Schema
{
    /// <summary>
    /// Information about a vendor's logo
    /// </summary>
    public class Logo
    {
        /// <summary>
        /// URI to the logo
        /// </summary>
        public Uri Url { get; set; }

        /// <summary>
        /// The logo's width, in pixels
        /// </summary>
        /// <remarks>API provides this as a string but it should always be an integer</remarks>
        public string Width { get; set; }

        /// <summary>
        /// The logo's height, in pixels
        /// </summary>
        /// <remarks>API provides this as a string but it should always be an integer</remarks>
        public string Height { get; set; }
    }
}
