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
}
