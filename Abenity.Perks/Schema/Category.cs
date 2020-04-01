using Newtonsoft.Json;
using System.Collections.Generic;

namespace Abenity.Perks.Schema
{
    public class Category
    {
        public string Id { get; set; }

        public string Key { get; set; }

        public string Title { get; set; }

        [JsonProperty("offer_count")]
        public int OfferCount { get; set; }

        public IEnumerable<Category> Children { get; set; }
    }
}
