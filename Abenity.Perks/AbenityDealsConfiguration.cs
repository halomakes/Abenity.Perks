using System;
using System.Collections.Generic;
using System.Text;

namespace Abenity.Perks
{
    public class AbenityDealsConfiguration
    {
        public string BaseUrl { get; set; } = "https://acme.abenity.com/perks/api";

        public string Username { get; set; }

        public string Password { get; set; } = "clientapp";
    }
}
