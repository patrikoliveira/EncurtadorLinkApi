using System.Threading.Tasks;
using EncurtadorLinkApi.Domain.Entities;
using EncurtadorLinkApi.Presentation.ViewModel;

namespace EncurtadorLinkApi.Domain.Services
{
    public interface ILinkService
    {
        Task<LinkEncurtado> CriarLink(LinkDto linkDto);

        public LinkEncurtado BuscarLink(string key);
    }
}