namespace EncurtadorLinkApi.Domain.Repositories
{
    public interface IRedisRepository
    {
        void SetValue<T>(string key, T value);
        T GetValue<T>(string key);
    }
}