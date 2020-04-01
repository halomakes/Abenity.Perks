using Abenity.Perks.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Abenity.Perks
{
    /// <summary>
    /// Client for fetching data from the Abenity Deals API
    /// </summary>
    public class AbenityPerksApiClient : IAbenityPerksApiClient
    {
        protected static JsonSerializerSettings settings = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Include,
            MissingMemberHandling = MissingMemberHandling.Ignore,
            DateTimeZoneHandling = DateTimeZoneHandling.Utc,
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        private readonly HttpClient httpClient;
        private readonly AbenityPerksConfiguration config;

        /// <summary>
        /// Construct an Abenity Deals API client
        /// </summary>
        /// <param name="config">Configuration for the API client</param>
        /// <param name="httpClient">HTTP client to make requests with</param>
        public AbenityPerksApiClient(AbenityPerksConfiguration config, HttpClient httpClient)
        {
            this.config = config;
            this.httpClient = httpClient;
            this.httpClient.BaseAddress = new Uri(config.BaseUrl);
            this.httpClient.DefaultRequestHeaders.Authorization = GetAuthHeader();
        }

        /// <summary>
        /// Get all available categories available to your account from the perks API
        /// </summary>
        /// <returns>A List of categories</returns>
        public Task<IEnumerable<Category>> GetCategoriesAsync() =>
            GetAsync<IEnumerable<Category>>("/v2/feed/categories.json");

        /// <summary>
        /// Get a list of offers for a given category
        /// </summary>
        /// <param name="category">Category to filter results by</param>
        /// <returns>A list of offer sets matching the category</returns>
        public Task<IEnumerable<OfferSet>> GetOffersAsync(Category category) =>
            GetOffersAsync(categoryId: category.Id);

        /// <summary>
        /// Get a list of offers for a given category ID or key
        /// </summary>
        /// <param name="categoryId">Category ID to filter by</param>
        /// <param name="categoryKey">Category Key to filter by; will be ignored if ID is present</param>
        /// <remarks>Either a category ID or a category key must be supplied; use a named parameter</remarks>
        /// <exception cref="ArgumentNullException">Neither a category ID nor a category Key was specified</exception>
        /// <returns>A list of offer sets matching the category</returns>
        public Task<IEnumerable<OfferSet>> GetOffersAsync(string categoryId = null, string categoryKey = null)
        {
            if (string.IsNullOrEmpty(categoryId) || string.IsNullOrEmpty(categoryKey))
                throw new ArgumentNullException("A categoryId or categoryKey must be supplied");
            if (string.IsNullOrEmpty(categoryId))
                return GetAsync<IEnumerable<OfferSet>>($"/v2/feed/categories.json?category_key={categoryKey}");
            return GetAsync<IEnumerable<OfferSet>>($"/v2/feed/categories.json?category_id={categoryId}");
        }

        private async Task<TResponse> GetAsync<TResponse>(string endpoint)
        {
            SetSecurityProtocol();
            using (var request = new HttpRequestMessage(HttpMethod.Get, endpoint))
            {
                var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                var stream = await response.Content.ReadAsStreamAsync();

                if (response.IsSuccessStatusCode)
                    return DeserializeJsonResponse<TResponse>(stream);

                throw new PerksException
                {
                    StatusCode = (int)response.StatusCode,
                    ResponseContent = await StreamToStringAsync(stream),
                    RequestContent = null,
                    Endpoint = endpoint
                };
            }
        }

        private TResponse DeserializeJsonResponse<TResponse>(Stream stream)
        {
            if (stream == null || stream.CanRead == false)
                return default;

            using (var sr = new StreamReader(stream))
            using (var jtr = new JsonTextReader(sr))
            {
                var js = new JsonSerializer();
                var model = js.Deserialize<TResponse>(jtr);
                return model;
            }
        }

        private static async Task<string> StreamToStringAsync(Stream stream)
        {
            string content = null;

            if (stream != null)
                using (var sr = new StreamReader(stream))
                    content = await sr.ReadToEndAsync();

            return content;
        }

        private static void SetSecurityProtocol() =>
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

        private AuthenticationHeaderValue GetAuthHeader() => new AuthenticationHeaderValue("Basic", $"{config.Username}:{config.Password}".ToByteArray().ToBase64());
    }
}
