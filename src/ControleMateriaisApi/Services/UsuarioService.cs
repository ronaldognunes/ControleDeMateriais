using AutoMapper;
using ControleMateriaisApi.Configurations;
using ControleMateriaisApi.Domain;
using ControleMateriaisApi.Dto;
using ControleMateriaisApi.Repository.Interfaces;
using ControleMateriaisApi.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ControleMateriaisApi.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public UsuarioService(IUsuarioRepository usuarioRepository
                             , IMapper mapper
                             , IOptions<AppSettings> opt)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _appSettings = opt.Value;
        }

        public async Task<ResponseDto<UsuarioDto>> AlterarUsuarioAsync(int id, UsuarioDto usuario)
        {
            var response = new ResponseDto<UsuarioDto>();
            var mensagensErros = usuario.ValidaAlterarUsuario();
            if (mensagensErros.Any())
            {
                response.MensagensDeErros.AddRange(mensagensErros);
                response.Sucesso = false;
                return response;
            }
            var usuarioEntity = _mapper.Map<Usuario>(usuario);
            if (usuarioEntity == null)
            {
                response.MensagensDeErros.Add("Usuário não encontrado!");
                response.Sucesso = false;
            }
            response.Sucesso = await _usuarioRepository.AlterarAsync(usuarioEntity);
            return response;
        }

        public async Task<ResponseDto<UsuarioDto>> CadastrarUsuarioAsync(UsuarioDto usuario)
        {
            var response = new ResponseDto<UsuarioDto>();
            var mensagensDeErros = usuario.ValidaCadastroUsuario();

            if (mensagensDeErros.Any())
            {
                response.MensagensDeErros.AddRange(mensagensDeErros);
                response.Sucesso = false;
                return response;
            }
            var usuarioEntity = _mapper.Map<Usuario>(usuario);

            await _usuarioRepository.CadastrarAsync(usuarioEntity);
            response.Sucesso = true;

            return response;
        }

        public async Task<ResponseDto<IList<UsuarioDto>>> ConsultarUsuariosPorNomesAsync(string nome)
        {
            var retorno = new ResponseDto<IList<UsuarioDto>>();
            var usuarios = await _usuarioRepository.RecuperarUsuariosPorNomeAsync(nome);
            var usuariosDto = _mapper.Map<IList<UsuarioDto>>(retorno);
            retorno.result = usuariosDto;

            return retorno;
        }

        public async Task<ResponseDto<UsuarioDto>> ConsultarUsuariosPorIdAsync(int id)
        {
            var retorno = new ResponseDto<UsuarioDto>();
            var usuarios = await _usuarioRepository.RecuperarPorIdAsync(id);
            var usuariosDto = _mapper.Map<UsuarioDto>(usuarios);
            retorno.result = usuariosDto;

            return retorno;
        }

        public async Task<ResponseDto<UsuarioDto>> DeletarUsuarioAsync(UsuarioDto usuario)
        {
            var retorno = new ResponseDto<UsuarioDto>();
            var mensagensErros = usuario.ValidaDeletarUsuario();
            if (mensagensErros.Any())
            {
                retorno.MensagensDeErros.AddRange(mensagensErros);
                return retorno;
            }
            var usuarioEntity = _mapper.Map<Usuario>(usuario);
            retorno.Sucesso = await _usuarioRepository.DeletarAsync(usuarioEntity);
            return retorno;
        }

        public async Task<ResponseDto<UsuarioDto>> EfetuarLoginAsync(UsuarioDto usuario)
        {
            var response = new ResponseDto<UsuarioDto>();
            var mensagensErros = usuario.ValidaLogin();
            if (mensagensErros.Any())
            {
                response.MensagensDeErros.AddRange(mensagensErros);
                response.Sucesso = false;
                return response;
            }

            var usuarioEntity = await _usuarioRepository.EfetuarLoginAsync(usuario.Email, usuario.Senha);

            if (usuarioEntity is null)
            {
                response.MensagensDeErros.Add("Usuario não encontrados, Email ou senha estão incorretos");
                response.Sucesso = false;
                return response;
            }

            var usuarioDto = _mapper.Map<UsuarioDto>(usuarioEntity);
            usuarioDto.Token = GerarJwt();
            response.result = usuarioDto;
            response.Sucesso = true;

            return response;
        }

        public async Task<ResponseDto<IList<UsuarioDto>>> ListarTodosUsuariosAsync()
        {
            var retorno = new ResponseDto<IList<UsuarioDto>>();
            var usuarios = await _usuarioRepository.RecuperarTodosAsync();

            retorno.result = _mapper.Map<IList<UsuarioDto>>(usuarios);
            retorno.Sucesso = true;
            return retorno;
        }

        private string GerarJwt()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Expires = DateTime.UtcNow.AddHours((double)_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });
            var encodedToken = tokenHandler.WriteToken(token);
            return encodedToken;
        }
    }
}
