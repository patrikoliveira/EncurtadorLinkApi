using AutoMapper;
using EncurtadorLinkApi.Domain.Entities;

namespace EncurtadorLinkApi.Presentation.ViewModel
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LinkEncurtado, LinkEncurtadoDto>()
                .ForMember(l => l.Hash, opt => opt.MapFrom(m => m.UrlEncurtada));
        }
    }
}