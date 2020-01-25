//using Microsoft.AspNetCore.Blazor.Browser.Rendering;
//using Microsoft.AspNetCore.Blazor.Browser.Services;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BlazorDDL.Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var serviceProvider = new BrowserServiceProvider(services =>
            //{
            //    // Add any custom services here
            //});

            ////new BrowserRenderer(serviceProvider).AddComponent<App>("app");

            CreateHostBuilder(args).Build().Run();
        }

        public static IWebAssemblyHostBuilder CreateHostBuilder(string[] args) =>
            BlazorWebAssemblyHost.CreateDefaultBuilder()
                .UseBlazorStartup<Startup>();
    }
}
