using Newtonsoft.Json;

namespace Abenity.Perks.Schema
{
    /// <summary>
    /// A location where a deal can be used
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Display name for the location
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Street address of the location
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// City/locality of the location
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// State/region of the location
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// ZIP/postal code of the location
        /// </summary>
        public string Zip { get; set; }

        /// <summary>
        /// Country of the location
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Latitude section of coordinates
        /// </summary>
        public string Latitude { get; set; }

        /// <summary>
        /// Longitude section of coordinates
        /// </summary>
        public string Longitude { get; set; }

        /// <summary>
        /// Describes the accuracy of the provides coordinates
        /// </summary>
        [JsonProperty("coordinate_accuracy")]
        public AccuracyLevel CoordinateAccuracy { get; set; }

        // don't know what this does.  let me know if you do
        [JsonProperty("arcgis_score")]
        public object ArcgisScore { get; set; }

        /// <summary>
        /// Phone number for the location
        /// </summary>
        /// <remarks>Formatted as XXX-XXX-XXXX</remarks>
        public string Phone { get; set; }

        /// <summary>
        /// Fax number for the location
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// Unique ID for the location
        /// </summary>
        /// <remarks>API provides as a string but it's a number inside</remarks>
        public string Id { get; set; }

        /// <summary>
        /// Describes the accuracy level of a coordinate set
        /// </summary>
        public enum AccuracyLevel
        {
            Address,
            Postal
        }
    }
}
