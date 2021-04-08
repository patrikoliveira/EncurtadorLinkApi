using System.Threading.Tasks;
using AutoMapper;
using EncurtadorLinkApi.Domain.Entities;
using EncurtadorLinkApi.Domain.Services;
using EncurtadorLinkApi.Presentation.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace EncurtadorLinkApi.Presentation.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class LinkController : Controller
    {
        private readonly ILinkService _linkService;
        private readonly IMapper _mapper;
        public LinkController(ILinkService linkService, IMapper mapper)
        {
            _linkService = linkService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("buscar-link")]
        public IActionResult Index([FromQuery] BuscarLinkDto buscarLinkDto)
        {
            var link = _linkService.BuscarLink(buscarLinkDto.Key);
            return StatusCode(200, _mapper.Map<LinkEncurtado, LinkEncurtadoDto>(link));
        }

        [HttpPost]
        [Route("encurtar-link")]
        public async Task<IActionResult> Create([FromBody] LinkDto linkDto)
        {
            var linkEncurtado = await _linkService.CriarLink(linkDto);
            return StatusCode(201, _mapper.Map<LinkEncurtado, LinkEncurtadoDto>(linkEncurtado));
        }
    }
}