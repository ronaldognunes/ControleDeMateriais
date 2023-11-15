using AutoMapper;
using ControleMateriaisApi.Domain;
using ControleMateriaisApi.Dto;

namespace ControleMateriaisApi.Mappings
{
    public class UsuarioToUsuarioDto : Profile
    {
        public UsuarioToUsuarioDto()
        {
            CreateMap<Usuario, UsuarioDto>()
                .ReverseMap();
        }
    }
    public class UsuarioToLoginDto : Profile
    {
        public UsuarioToLoginDto()
        {
            CreateMap<Usuario, LoginDto>()
                .ReverseMap();
        }
    }

    public class UsuarioToUsuarioCadastroDto : Profile
    {
        public UsuarioToUsuarioCadastroDto()
        {
            CreateMap<Usuario, UsuarioCadastroDto>()
                .ReverseMap();
        }
    }

    public class UsuarioToRetornoDadosLoginDto : Profile
    {
        public UsuarioToRetornoDadosLoginDto()
        {
            CreateMap<Usuario, RetornoDadosLoginDto>()
                .ReverseMap();
        }
    }

    public class UsuarioToAlteracaoUsuarioDto : Profile
    {
        public UsuarioToAlteracaoUsuarioDto()
        {
            CreateMap<Usuario, AlteracaoUsuarioDto>()
                .ReverseMap();
        }
    }
}
