using EncurtadorLinkApi.Domain.Repositories;
using EncurtadorLinkApi.Domain.Services;

namespace EncurtadorLinkApi.Services
{
    public class RedisService : IRedisService
    {
        private readonly IRedisRepository _redisRepository;

        public RedisService(IRedisRepository redisRepository)
        {
            _redisRepository = redisRepository;
        }

        public void Inserir<T>(string key, T entity)
        {
            _redisRepository.SetValue<T>(key, entity);
        }

        public T Buscar<T>(string key)
        {
            return _redisRepository.GetValue<T>(key);
        }
    }
}