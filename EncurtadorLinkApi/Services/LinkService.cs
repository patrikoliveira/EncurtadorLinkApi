using System;
using System.Threading.Tasks;
using EncurtadorLinkApi.Domain.Entities;
using EncurtadorLinkApi.Domain.Services;
using EncurtadorLinkApi.Presentation.ViewModel;

namespace EncurtadorLinkApi.Services
{
    public class LinkService : ILinkService
    {

        private readonly IRedisService _redisService;
        private readonly ILinkEncurtadoService _encurtadorLinkService;

        public LinkService(IRedisService redisService, ILinkEncurtadoService encurtadorLinkService)
        {
            _redisService = redisService;
            _encurtadorLinkService = encurtadorLinkService;
        }

        public async Task<LinkEncurtado> CriarLink(LinkDto linkDto)
        {
            var hash = _encurtadorLinkService.CriarHash($"{linkDto.Domain}{linkDto.Resource}&user_id{linkDto.UserId}");
            var linkEncurtado = new LinkEncurtado {
                Domain = linkDto.Domain,
                Resource = linkDto.Resource,
                Hash = hash,
                UrlEncurtada = $"{linkDto.Domain}{hash}",
                UserId = linkDto.UserId
            };
            
            await _encurtadorLinkService.Create(linkEncurtado);
            
            _redisService.Inserir(linkEncurtado.UrlEncurtada, linkEncurtado);
            return linkEncurtado;
        }

        public LinkEncurtado BuscarLink(string key)
        {
            var linkEncurtado = _redisService.Buscar<LinkEncurtado>(key);

            return linkEncurtado;
        }
    }
}