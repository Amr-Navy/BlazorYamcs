using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Yamcs.Client.Services;
using MudBlazor.Services;
namespace Yamcs.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
           
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddOptions();
            AddHttpClients(builder, builder.Configuration);
            builder.Services.AddScoped(x => new WebSocketClient(new ClientWebSocket()));
            builder.Services.AddScoped<YamcsClient>();
            builder.Services.AddSingleton<InstantState>();
            builder.Services.AddMudServices();
            await builder.Build().RunAsync();
        }
        public static void AddHttpClients(WebAssemblyHostBuilder builder, IConfiguration configuration)
        {
            string baseAddress = configuration["BaseAddress"];

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });


        }
    }
}
