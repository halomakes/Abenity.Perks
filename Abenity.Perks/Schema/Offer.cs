using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Abenity.Perks.Schema
{
    public class Offer
    {
        [JsonProperty("category_id")]
        public string CategoryId { get; set; }

        [JsonProperty("exp_date")]
        public DateTime ExpirationDate { get; set; }

        public IEnumerable<Location> Locations { get; set; }

        [JsonProperty("days_old")]
        public int DaysOld { get; set; }

        public string Id { get; set; }

        public string Title { get; set; }

        public Uri Link { get; set; }
    }
}
