using AutoMapper;
using ControleMateriaisApi.Domain;
using ControleMateriaisApi.Dto;

namespace ControleMateriaisApi.Mappings
{
    public class OrdemServicoToOrdemServicoDto : Profile
    {
        public OrdemServicoToOrdemServicoDto()
        {
            CreateMap<OrdemServico,OrdemServicoDto>()
                .ReverseMap();
        }
    }
}
