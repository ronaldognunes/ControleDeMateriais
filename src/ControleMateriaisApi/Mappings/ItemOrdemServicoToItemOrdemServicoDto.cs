using AutoMapper;
using ControleMateriaisApi.Domain;
using ControleMateriaisApi.Dto;

namespace ControleMateriaisApi.Mappings
{
    public class ItemOrdemServicoToItemOrdemServicoDto : Profile
    {
        public ItemOrdemServicoToItemOrdemServicoDto()
        {
            CreateMap<ItemOrdemServico,ItemOrdemServicoDto>()
                .ReverseMap();
        }
    }

    public class ItemOrdemServicoToCadastroItemOrdemServicoDto : Profile
    {
        public ItemOrdemServicoToCadastroItemOrdemServicoDto()
        {
            CreateMap<ItemOrdemServico, CadastroItemOrdemServicoDto>()
                .ReverseMap();
        }
    }

    public class ItemOrdemServicoToAlteracaoItemOrdemServicoDto : Profile
    {
        public ItemOrdemServicoToAlteracaoItemOrdemServicoDto()
        {
            CreateMap<ItemOrdemServico, AlteracaoItemOrdemServicoDto>()
                .ReverseMap();
        }
    }
}
