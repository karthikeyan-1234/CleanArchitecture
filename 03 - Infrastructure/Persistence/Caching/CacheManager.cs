using _02___Application.Contracts;

using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _03___Infrastructure.Persistence.Caching
{
    public class CacheManager : ICacheManager
    {
        IDistributedCache cache;
        DistributedCacheEntryOptions options;
        ILogger<CacheManager> logger;

        public CacheManager(IDistributedCache cache, ILogger<CacheManager> logger)
        {
            this.cache = cache;
            options = new DistributedCacheEntryOptions() { AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60), SlidingExpiration = TimeSpan.FromSeconds(15) };
            this.logger = logger;
        }

        public async Task<bool> TrySetAsync<T>(string key, T entry)
        {
            try
            {
                var user = "";//sessionService?.GetString("user");
                string json = JsonSerializer.Serialize(entry);
                await cache.SetStringAsync(user + "-" + key, json, options);
                logger.LogInformation("Cache set for Key {0}", key);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError("Error in getting Redis Cache" + ex.Message);
                return false;
            }
        }

        public async Task<T?> TryGetAsync<T>(string key)
        {
            try
            {
                var user = "";// sessionService?.GetString("user");
                var json = await cache.GetStringAsync(user + "-" + key);
                if (json != null)
                    return JsonSerializer.Deserialize<T>(json);
                return default(T);
            }
            catch (Exception ex)
            {
                logger.LogError("Error in getting Redis Cache" + ex.Message);
                return default;
            }
        }
    }
}
