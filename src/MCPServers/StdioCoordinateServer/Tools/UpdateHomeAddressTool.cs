using System.ComponentModel;
using ModelContextProtocol.Server;
using StdioCoordinateServer.Records;
using StdioCoordinateServer.Resources;

namespace StdioCoordinateServer.Tools;

[McpServerToolType]
public class UpdateHomeAddressTool
{
    /// <summary>
    /// Retrieves the coordinates from the LLM and updates the resource’s property
    /// </summary>
    [McpServerTool(Name = "update_home_address_coordinates", Title = "Update Home Address Coordinates")]
    [Description("Updates the user's home address coordinates.")]
    public void UpdateHomeAddress(decimal latitude, decimal longitude)
    {
        HomeAddressResource.HomeAddressCoordinates = new Coordinates(latitude, longitude);
    }
}