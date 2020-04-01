using Abenity.Perks.Schema;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Abenity.Perks
{
    /// <summary>
    /// Client for fetching data from the Abenity Deals API
    /// </summary>
    public interface IAbenityPerksApiClient
    {
        /// <summary>
        /// Get all available categories available to your account from the perks API
        /// </summary>
        /// <returns>A List of categories</returns>

        Task<IEnumerable<Category>> GetCategoriesAsync();

        /// <summary>
        /// Get a list of offers for a given category
        /// </summary>
        /// <param name="category">Category to filter results by</param>
        /// <returns>A list of offer sets matching the category</returns>
        Task<IEnumerable<OfferSet>> GetOffersAsync(Category category);

        /// <summary>
        /// Get a list of offers for a given category ID or key
        /// </summary>
        /// <param name="categoryId">Category ID to filter by</param>
        /// <param name="categoryKey">Category Key to filter by; will be ignored if ID is present</param>
        /// <remarks>Either a category ID or a category key must be supplied; use a named parameter</remarks>
        /// <exception cref="ArgumentNullException">Neither a category ID nor a category Key was specified</exception>
        /// <returns>A list of offer sets matching the category</returns>

        Task<IEnumerable<OfferSet>> GetOffersAsync(string categoryId = null, string categoryKey = null);
    }
}