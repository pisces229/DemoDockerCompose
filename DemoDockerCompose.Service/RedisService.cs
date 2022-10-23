using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;

namespace DemoDockerCompose.Service
{
    public class RedisService
    {
        private readonly ILogger<RedisService> _logger;
        private readonly IDistributedCache _cache;
        public RedisService(ILogger<RedisService> logger,
            IDistributedCache cache)
        {
            _logger = logger;
            _cache = cache;
        }
        public Task Set(string key, string value) => _cache.SetStringAsync(key, value);
        public Task<string> Get(string key) => _cache.GetStringAsync(key);
    }
}