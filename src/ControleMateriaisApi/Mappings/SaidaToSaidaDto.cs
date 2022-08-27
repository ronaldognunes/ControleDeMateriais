using AutoMapper;
using ControleMateriaisApi.Domain;
using ControleMateriaisApi.Dto;

namespace ControleMateriaisApi.Mappings
{
    public class SaidaToSaidaDto:Profile
    {
        public SaidaToSaidaDto()
        {
            CreateMap<Saida,SaidaDto>()
                .ReverseMap();
        }
    }
}
