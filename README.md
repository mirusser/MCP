Playground repo to check out MCP

To run local stdio MCP server in OpenCode,
create a file: `~/.config/opencode/opencode.json`
with content:
```json
{
    "$schema": "https://opencode.ai/config.json",
    "mcp": {
        "stdio-coordinate-server": {
        "type": "local",
        "command": ["/home/mirusser/MyRepos/GitRepos/MCP/src/MCPServers/StdioCoordinateServer/bin/Release/net10.0/publish/StdioCoordinateServer"],
        "enabled": true,
        "environment": {
            "DOTNET_ENVIRONMENT": "Development"
          }
        }
    }
}
```

`command` can also look like this:
```
"command": ["dotnet", "run", "--project", "/home/mirusser/MyRepos/GitRepos/MCP/src/MCPServers/StdioCoordinateServer/StdioCoordinateServer.csproj"]
```

*NOTE:*
Prefer `"command": ["dotnet", "run", "--project", "..."]` while iterating (no republish needed).
Prefer `"command": ["/abs/path/to/publish/YourServer"]` for reliability when you want it stable.

Test it with command:
```bash
opencode mcp list
```

You should see your server `connected`

Check [OpenCode MCP servers documentation](https://opencode.ai/docs/mcp-servers/?utm_source=chatgpt.com)

It seems that OpenCode doesn't fully support prompts discovery (yet), so there are two options to go about it:
- Expose “prompts” as MCP tools (so OpenCode can call them, because tools are the first-class integration point).
- Put reusable prompts into OpenCode slash commands under .opencode/commands/prompt-name.md (or user-level commands), and run them as /prompt-name.
[OpenCode Prompt config](https://opencode.ai/docs/commands/#prompt-config)

Also, it seems that OpenCode doesn't support local resources (yet) and it requires http:, https: or s3: protocols