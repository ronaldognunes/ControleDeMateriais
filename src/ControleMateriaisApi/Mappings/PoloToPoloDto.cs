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
}
