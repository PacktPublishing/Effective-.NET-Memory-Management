using Newtonsoft.Json;
using StackExchange.Redis;

namespace Caching.Api.Chapter08;

public class CacheService
{
    private readonly IDatabase _cache;

    public CacheService()
    {
        _cache = RedisConnection.Connection.GetDatabase();
    }

    public async Task SetCacheAsync<T>(string key, T value, TimeSpan expiration)
    {
        var jsonData = JsonConvert.SerializeObject(value);
        await _cache.StringSetAsync(key, jsonData, expiration);
    }

    public async Task<T> GetCacheAsync<T>(string key)
    {
        var jsonData = await _cache.StringGetAsync(key);
        if (jsonData.IsNullOrEmpty)
        {
            return default(T);
        }
        return JsonConvert.DeserializeObject<T>(jsonData);
    }

    public async Task RemoveCacheAsync(string key)
    {
        await _cache.KeyDeleteAsync(key);
    }
}

