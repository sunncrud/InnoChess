using InnoChess.Application.Caching;
using Microsoft.Extensions.Caching.Memory;

namespace InnoChess.Infrastructure; 

public class InMemoryCacheService(IMemoryCache memoryCache) : ICacheService
{
    private static readonly TimeSpan DefaultExpiration = TimeSpan.FromMinutes(10);
    
    public async Task<T?> GetOrCreateAsync<T>(
        string key, 
        Func<CancellationToken, Task<T?>> factory, 
        TimeSpan? expiration = null, 
        CancellationToken cancellationToken = default)
    {
        if (memoryCache.TryGetValue(key, out T? cachedItem))
        {
            return cachedItem;
        }
        
        var item = await factory(cancellationToken);

        if (item == null) return item;
        var cacheOptions = new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = expiration ?? DefaultExpiration,
            SlidingExpiration = TimeSpan.FromMinutes(2)
        };

        memoryCache.Set(key, item, cacheOptions);

        return item;
    }

    public void Remove(string key)
    {
        memoryCache.Remove(key);
    }
}