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
}
