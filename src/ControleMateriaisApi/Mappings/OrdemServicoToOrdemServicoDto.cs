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

    public class OrdemServicoToCadastroOrdemServicoDto : Profile
    {
        public OrdemServicoToCadastroOrdemServicoDto()
        {
            CreateMap<OrdemServico, CadastroOrdemServicoDto>()
                .ReverseMap();
        }
    }

    public class OrdemServicoToAlteracaoOrdemServicoDto : Profile
    {
        public OrdemServicoToAlteracaoOrdemServicoDto()
        {
            CreateMap<OrdemServico, AlteracaoOrdemServicoDto>()
                .ReverseMap();
        }
    }

    public class OrdemServicoToRetornoOrdemServicoDto : Profile
    {
        public OrdemServicoToRetornoOrdemServicoDto()
        {
            CreateMap<OrdemServico, RetornoOrdemServicoDto>()
                .ReverseMap();
        }
    }
}
