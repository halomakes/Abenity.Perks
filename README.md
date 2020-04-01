# Abenity.Perks [![NuGet Logo](https://raw.githubusercontent.com/NuGet/Media/master/Images/MainLogo/32x32/nuget_32.png)](https://www.nuget.org/packages/Abenity.Perks/)
.NET Standard API Client for interacting with the [Abenity Perks API](https://abenity.com/developers/api/perks)
This can be used alongside the [Abenity.Members](https://github.com/halomademeapc/Abenity.Members) library to send users directly to a deal's details page.

> This code has not been fully-tested and is provided as-is.  I do not have an account with access to the Perks API so this is based on the [limited documentation](https://abenity.com/developers/api/perks) at Abenity's developer site.  If you have any issues please let me know or submit a bug and I will take a look.  

## Configuration
The following information is required to authorize API requests.  
1. A "username" (an API key)
2. Your client subdomain (mycompany.abenity.com)

Provided below is an example configuration section.  
```json
"Perks": {
    "BaseUrl": "https://YOUR_COMPANY.abenity.com/perks/api",
    "Username": "abcdefghijkl"
}
```

## Example Usage
Register the API Client in your application's service provider
```csharp
var config = new AbenityPerksConfiguration();
Configuration.Bind("Perks", config);
services.AddSingleton(config);

services.AddHttpClient();
services.AddScoped<IAbenityPerksApiClient, AbenityPerksApiClient>();
```

Inject it into your service/controller and make a call
```csharp
private readonly IAbenityPerksApiClient perksClient;

public MyService(IAbenityPerksApiClient perksClient) {
    this.perksClient = perksClient;
}

// Get offers using a category object
public async Task<IEnumerable<OfferSet>> GetOffers() {
    var category = (await perksClient.GetCategoriesAsync()).FirstOrDefault();
    var deals = await perksClient.GetOffersAsync(category);
    return deals;
}

// Get offers using a category key
public Task<IEnumerable<OfferSet>> GetOffers(string key) => perksClient.GetOffersAsync(categoryKey: key);

// Get offers using a category ID
public Task<IEnumerable<OfferSet>> GetOffersById(string id) =>  perksClient.GetOffersAsync(categoryId: id);
```

## Dependencies
* **Newtonsoft.Json** 10.0.3+

## Changelog
**0.1.0-alpha** Initial Preview