using EncurtadorLinkApi.Presentation.ViewModel;

namespace EncurtadorLinkApi.Domain.Services
{
    public interface IRedisService
    {
        public void Inserir<T>(string key, T linkDto);
        public T Buscar<T>(string key);
    }
}