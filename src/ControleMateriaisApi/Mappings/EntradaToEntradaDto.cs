using AutoMapper;
using ControleMateriaisApi.Domain;
using ControleMateriaisApi.Dto;

namespace ControleMateriaisApi.Mappings
{
    public class EntradaToEntradaDto : Profile
    {
        public EntradaToEntradaDto()
        {
            CreateMap<Entrada,EntradaDto>()
                .ReverseMap();
        }
    }
}
