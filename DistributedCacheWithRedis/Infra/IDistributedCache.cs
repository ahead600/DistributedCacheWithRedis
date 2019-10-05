using Microsoft.Extensions.Caching.Distributed;
using System.Threading.Tasks;

namespace DistributedCacheWithRedis
{
    public interface IDistributedCache
    {
        byte[] Get(string key);
        Task<byte[]> GetAsync(string key);

        void Set(string key, byte[] value, DistributedCacheEntryOptions options);
        Task SetAsync(string key, byte[] value, DistributedCacheEntryOptions options);

        void Refresh(string key);
        Task RefreshAsync(string key);

        void Remove(string key);
        Task RemoveAsync(string key);
    }


}
