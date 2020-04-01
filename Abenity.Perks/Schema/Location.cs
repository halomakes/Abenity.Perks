using Newtonsoft.Json;

namespace Abenity.Perks.Schema
{
    public class Location
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string Country { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        [JsonProperty("coordinate_accuracy")]
        public string CoordinateAccuracy { get; set; }

        [JsonProperty("arcgis_score")]
        public object ArcgisScore { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public string Id { get; set; }
    }

}
