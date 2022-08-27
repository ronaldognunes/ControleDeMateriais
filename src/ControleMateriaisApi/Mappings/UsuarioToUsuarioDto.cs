using AutoMapper;
using ControleMateriaisApi.Domain;
using ControleMateriaisApi.Dto;

namespace ControleMateriaisApi.Mappings
{
    public class UsuarioToUsuarioDto:Profile
    {
        public UsuarioToUsuarioDto()
        {
            CreateMap<Usuario, UsuarioDto>()
                //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                //.ForMember(dest => dest.Perfil, opt => opt.MapFrom(src => src.Perfil))
                //.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                //.ForMember(dest => dest.Senha, opt => opt.MapFrom(src => src.Senha))
                //.ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(src => src.DataCadastro))
                //.ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ReverseMap();
               // .ForAllMembers(opt => opt.Ignore());
        }
    }
}
