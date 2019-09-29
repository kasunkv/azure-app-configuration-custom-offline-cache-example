using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using System.IO;

namespace CustomOfflineCacheExample.Cache
{
    public class LocalFileOfflineCache : IOfflineCache
    {
        private readonly string _cacheFilePath;

        public LocalFileOfflineCache(IHostingEnvironment env)
        {
            _cacheFilePath = Path.Combine(env.WebRootPath, "offline_cache.json");
        }

        public void Export(AzureAppConfigurationOptions options, string data)
        {
            File.WriteAllText(_cacheFilePath, data);
        }

        public string Import(AzureAppConfigurationOptions options)
        {
            var cacheData = File.ReadAllText(_cacheFilePath);
            return cacheData;
        }
    }
}
