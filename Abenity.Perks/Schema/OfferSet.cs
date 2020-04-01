using System.Collections.Generic;

namespace Abenity.Perks.Schema
{
    /// <summary>
    /// A grouping of a vendor and the perks they offer
    /// </summary>
    public class OfferSet
    {
        /// <summary>
        /// Information about the vendor
        /// </summary>
        public Vendor Vendor { get; set; }

        /// <summary>
        /// A list of perks offered by the vendor
        /// </summary>
        public IEnumerable<Offer> Offers { get; set; }
    }
}
