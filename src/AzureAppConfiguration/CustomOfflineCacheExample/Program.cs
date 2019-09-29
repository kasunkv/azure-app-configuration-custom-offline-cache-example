using CustomOfflineCacheExample.Cache;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;

namespace CustomOfflineCacheExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost
                .CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    var settings = config.Build();
                    config.AddAzureAppConfiguration(options =>
                    {
                        options
                            .Connect(settings["ConnectionStrings:AppConfiguration"])
                            .SetOfflineCache(new LocalFileOfflineCache(context.HostingEnvironment));
                    });

                })
                .UseStartup<Startup>();
    }
}
