using System.Threading.Tasks;
using EncurtadorLinkApi.Domain.Entities;

namespace EncurtadorLinkApi.Domain.Services
{
    public interface ILinkEncurtadoService
    {
        string CriarHash(string resource, uint seed = 128);

        Task<LinkEncurtado> Create(LinkEncurtado link);
    }
}