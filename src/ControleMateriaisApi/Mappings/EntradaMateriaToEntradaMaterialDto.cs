using AutoMapper;
using ControleMateriaisApi.Domain;
using ControleMateriaisApi.Dto;

namespace ControleMateriaisApi.Mappings
{
    public class EntradaMateriaToEntradaMaterialDto : Profile
    {
        public EntradaMateriaToEntradaMaterialDto()
        {
            CreateMap<EntradaMaterial,EntradaMaterialDto>()
                .ReverseMap();
        }
    }
}
