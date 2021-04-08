using EncurtadorLinkApi.Domain.Repositories;
using ServiceStack.Redis;

namespace EncurtadorLinkApi.Infrastructure.Repositories
{
    public class RedisRepository : IRedisRepository
    {
        private readonly RedisClient _redisClient;

        public RedisRepository(RedisClient redisClient)
        {
            _redisClient = redisClient;
        }

        public void SetValue<T>(string key, T value)
        {
            _redisClient.Set<T>(key, value);
        }

        public T GetValue<T>(string key)
        {
            return _redisClient.Get<T>(key);
        }
  }
}