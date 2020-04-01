using System.Collections.Generic;

namespace Abenity.Perks.Schema
{
    public class OfferSet
    {
        public Vendor Vendor { get; set; }

        public IEnumerable<Offer> Offers { get; set; }
    }

}
