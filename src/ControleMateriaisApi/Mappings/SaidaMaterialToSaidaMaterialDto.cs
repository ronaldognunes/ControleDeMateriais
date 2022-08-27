using AutoMapper;
using ControleMateriaisApi.Domain;
using ControleMateriaisApi.Dto;

namespace ControleMateriaisApi.Mappings
{
    public class SaidaMaterialToSaidaMaterialDto:Profile
    {
        public SaidaMaterialToSaidaMaterialDto()
        {
            CreateMap<SaidaMaterial,SaidaMaterialDto>()
                .ReverseMap();
        }
    }
}
