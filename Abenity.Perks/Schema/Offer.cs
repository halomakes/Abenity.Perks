using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Abenity.Perks.Schema
{
    /// <summary>
    /// A perk offered by a vendor
    /// </summary>
    public class Offer
    {
        /// <summary>
        /// ID of the category the offer is in
        /// </summary>
        [JsonProperty("category_id")]
        public string CategoryId { get; set; }

        /// <summary>
        /// Date when the offer will expire
        /// </summary>
        [JsonProperty("exp_date")]
        public DateTime ExpirationDate { get; set; }

        /// <summary>
        /// A list of locations where the offer can be used
        /// </summary>
        public IEnumerable<Location> Locations { get; set; }

        /// <summary>
        /// How many days the deal has been listed
        /// </summary>
        [JsonProperty("days_old")]
        public int DaysOld { get; set; }

        /// <summary>
        /// Unique ID of the deal
        /// </summary>
        /// <remarks>Will always be an integer but the API provides it as a string</remarks>
        public string Id { get; set; }

        /// <summary>
        /// Display name of the deal
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Link to frontend details page for the deal
        /// </summary>
        public Uri Link { get; set; }
    }
}
