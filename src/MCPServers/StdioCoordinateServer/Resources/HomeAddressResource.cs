using System.ComponentModel;
using System.Text.Json;
using ModelContextProtocol.Server;
using StdioCoordinateServer.Records;

namespace StdioCoordinateServer.Resources;

[McpServerResourceType]
public class HomeAddressResource
{
    private readonly JsonSerializerOptions jsonSerializerOptions = new(JsonSerializerDefaults.Web);
  
    public static Coordinates? HomeAddressCoordinates { get; set; }
  
    [McpServerResource(Name = "home_address_coordinates", Title = "Home Address Coordinates", MimeType = "application/json")]
    [Description("The user's home address coordinates, if it's set.")]
    public string GetHomeAddress()
    {
        // Return error if not set
        if (HomeAddressCoordinates is null)
        {
            return JsonSerializer.Serialize(new
                {
                    Error = "The user's home address has not been set"
                },
                jsonSerializerOptions);
        }
      
        // Return coordinates as JSON if set
        return JsonSerializer.Serialize(HomeAddressCoordinates, jsonSerializerOptions);
    }
}