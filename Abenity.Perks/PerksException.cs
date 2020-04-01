using System;

namespace Abenity.Perks
{
    public class PerksException : Exception
    {
        public int StatusCode { get; set; }
        public string Endpoint { get; set; }
        public string ResponseContent { get; set; }
        public string RequestContent { get; set; }
    }
}
