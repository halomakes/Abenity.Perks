using Newtonsoft.Json;
using System.Collections.Generic;

namespace Abenity.Perks.Schema
{
    /// <summary>
    /// A category for deals to be organized into
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Unique identifier for the category
        /// </summary>
        /// <remarks>Should always be a number, but the API delivers it as a string for some reason</remarks>
        public string Id { get; set; }

        /// <summary>
        /// Unique string identifier for the category
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Display title for the category
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Number of offers within the category
        /// </summary>
        [JsonProperty("offer_count")]
        public int OfferCount { get; set; }

        /// <summary>
        /// Nested sub-categories
        /// </summary>
        /// <remarks>Will be null when there are no children, not empty</remarks>
        public IEnumerable<Category> Children { get; set; }
    }
}
