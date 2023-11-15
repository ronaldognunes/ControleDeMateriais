using AutoMapper;
using ControleMateriaisApi.Domain;
using ControleMateriaisApi.Dto;

namespace ControleMateriaisApi.Mappings
{
    public class PoloToPoloDto:Profile
    {
        public PoloToPoloDto()
        {
            CreateMap<Polo,PoloDto>()
                .ReverseMap();
        }
    }
    //
    public class PoloToCadastroPoloDto : Profile
    {
        public PoloToCadastroPoloDto()
        {
            CreateMap<Polo, CadastroPoloDto>()
                .ReverseMap();
        }
    }
}
