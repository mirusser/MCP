using System.ComponentModel;
using System.Text.Json;
using ModelContextProtocol.Server;

namespace StreamableHttpGeocodingServer.Tools;

// Record to deserialize the OpenWeatherMap Geocoding results
public record GeocodingSearchResult(string Name, decimal Lat, decimal Lon, string Country);

[McpServerToolType]
public class LocationCoordinateLookupTool(IHttpClientFactory httpClientFactory)
{
    private readonly HttpClient httpClient = httpClientFactory.CreateClient("OpenWeatherMap");
    private readonly JsonSerializerOptions jsonSerializerOptions = new(JsonSerializerDefaults.Web);
  
    [McpServerTool, Description("Search for a location and retrieve its coordinates")]
    public async Task<string> SearchLocationCoordinates(
        [Description("Query containing the city name and ISO 3166 country code")] string query)
    {
        var response = await httpClient
            .GetFromJsonAsync<GeocodingSearchResult[]>($"/geo/1.0/direct?q={query}&limit=1");

        var result = response?.FirstOrDefault();
        if (result is null)
        {
            return JsonSerializer.Serialize(new
            {
                Error = "Could not find coordinates for the specified location."
            }, jsonSerializerOptions);
        }

        return JsonSerializer.Serialize(new
        {
            result.Name, 
            result.Country, 
            Latitude = result.Lat, 
            Longitude = result.Lon
        }, jsonSerializerOptions);
    }
}