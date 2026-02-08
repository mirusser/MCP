using System.ComponentModel;
using ModelContextProtocol.Server;

namespace StdioCoordinateServer.Prompts;

[McpServerPromptType]
public class UpdateHomeAddressPrompt
{
    [McpServerPrompt(Name = "update_home_address_prompt", Title = "Update Home Address Prompt")]
    [Description("A prompt to update the user's home address.")]
    public string GetUpdateHomeAddressPrompt(decimal latitude, decimal longitude) =>
        $"Please update the user's home address to latitude {latitude} and longitude {longitude}.";
}