namespace Abenity.Perks
{
    /// <summary>
    /// Configuration values for the Abenity perks configuration
    /// </summary>
    public class AbenityPerksConfiguration
    {
        /// <summary>
        /// Base URL of the perks API for your account
        /// </summary>
        /// <remarks>Will be https://YOUR_COMPANY.abenity.com/perks/api</remarks>
        public string BaseUrl { get; set; }

        /// <summary>
        /// Perks API key
        /// </summary>
        /// <remarks>These can be obtained from your Client Executive</remarks>
        public string Username { get; set; }

        /// <summary>
        /// Perks API password
        /// </summary>
        /// <remarks>Should always be "clientapp" according to perks documentation</remarks>
        public string Password { get; set; } = "clientapp";
    }
}
