using AutoMapper;
using ControleMateriaisApi.Domain;
using ControleMateriaisApi.Dto;

namespace ControleMateriaisApi.Mappings
{
    public class MaterialToMaterialDto :Profile
    {
        public MaterialToMaterialDto()
        {
            CreateMap<Material,MaterialDto>()
                .ReverseMap();
        }
    }

    public class MaterialToCadastroMaterialDto : Profile
    {
        public MaterialToCadastroMaterialDto()
        {
            CreateMap<Material, CadastroMaterialDto>()
                .ReverseMap();
        }
    }
}
