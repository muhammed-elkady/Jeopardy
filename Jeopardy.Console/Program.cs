using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Jeopardy.Console.Services.JeopardyScraper;
using Jeopardy.Console.Services.CsvWriter;
using Jeopardy.Console.Services.ClientApp;
using Microsoft.Extensions.Logging;

using IHost host = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        services.AddHttpClient();
        services.AddSingleton<IClientApp, ClientApp>();
        services.AddSingleton<IJeopardyScraper, JeopardyScraper>();
        services.AddSingleton<ICsvWriter, CsvWriter>();
    })
    .ConfigureLogging(logging => logging.ClearProviders())
    .Build();

var clientApp = host.Services.GetService<IClientApp>();
clientApp?.StartApp();
