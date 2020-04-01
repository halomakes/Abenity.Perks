namespace Abenity.Perks.Schema
{
    /// <summary>
    /// Information about a perk vendor
    /// </summary>
    public class Vendor
    {
        /// <summary>
        /// Display name of the vendor
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Unique ID of the vendor
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Information about the company's logo image, if present
        /// </summary>
        public Logo Logo { get; set; }
    }
}
