var builder = WebApplication.CreateBuilder(args);
{
    // Register HttpClient to call OpenWeatherMap API
    builder.Services.AddHttpClient("OpenWeatherMap", client =>
    {
        var baseUrl = builder.Configuration["OpenWeatherMap:BaseUrl"] ??
                      throw new InvalidOperationException("OpenWeatherMap Base URL not configured");
        var apiKey = builder.Configuration["OpenWeatherMap:ApiKey"] ??
                     throw new InvalidOperationException("OpenWeatherMap API key not configured.");

        client.BaseAddress = new Uri(baseUrl);
        client.DefaultRequestHeaders.Add("x-api-key", apiKey);
    });

    // Register MCP Server with HTTP Transport
    builder.Services
        .AddMcpServer()
        .WithHttpTransport()
        .WithToolsFromAssembly();
}

var app = builder.Build();
{
    app.MapMcp();
}

await app.RunAsync();