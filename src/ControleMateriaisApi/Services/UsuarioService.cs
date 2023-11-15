using AutoMapper;
using ControleMateriaisApi.Configurations;
using ControleMateriaisApi.Domain;
using ControleMateriaisApi.Dto;
using ControleMateriaisApi.Repository.Interfaces;
using ControleMateriaisApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ControleMateriaisApi.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        private readonly IEnvioDeEmailService _emailService;
        private readonly IOrdemServicoRepository _ordemServicoRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository
                             , IMapper mapper
                             , IOptions<AppSettings> opt
                             , IEnvioDeEmailService emailService
                             , IOrdemServicoRepository ordemServicoRepository)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _appSettings = opt.Value;
            _emailService = emailService;
            _ordemServicoRepository = ordemServicoRepository;
        }

        public async Task<ResponseDto<UsuarioDto>> AlterarUsuarioAsync(int id, AlteracaoUsuarioDto usuario)
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

        public async Task<ResponseDto<UsuarioDto>> CadastrarUsuarioAsync(UsuarioCadastroDto usuario)
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

            var jaExisteEsseUsuario = await _usuarioRepository
                .RecuperarDadosPorFiltroAsync(u => u.Email.ToLower() == usuarioEntity.Email.ToLower() ||
                                              u.Nome.ToLower() == usuarioEntity.Nome.ToLower());

            if (jaExisteEsseUsuario is null)
            {
                await _usuarioRepository.CadastrarAsync(usuarioEntity);
                response.Sucesso = true;
                return response;
            }

            response.MensagensDeErros.Add("Email ou nome já existe!");
            response.Sucesso = false;
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
            if (usuarios is null)
            {
                retorno.MensagensDeErros.Add("Nenhum registro Encontrado");
                retorno.Sucesso = false;
                return retorno;
            }
            var usuariosDto = _mapper.Map<UsuarioDto>(usuarios);
            retorno.Sucesso = true;
            retorno.result = usuariosDto;

            return retorno;
        }

        [Authorize(Roles = "Administrador")]
        public async Task<ResponseDto<UsuarioDto>> DeletarUsuarioAsync(int id)
        {
            var retorno = new ResponseDto<UsuarioDto>();
            var usuario = await _usuarioRepository.RecuperarPorIdAsync(id);
            if (usuario is null)
            {
                retorno.MensagensDeErros.Add("Usuario não encontrado.");
                return retorno;
            }
            var ExisteUsuarioCadastradoEmUmaOs = await _ordemServicoRepository.VerificaUsuarioPertenceAlgumaOs(id);
            if (ExisteUsuarioCadastradoEmUmaOs)
            {
                retorno.MensagensDeErros.Add("Usuario não pode ser excluido, pois já está cadastrado em um Ordem de serviço.");
                retorno.Sucesso = false;
                return retorno;
            }
            retorno.Sucesso = await _usuarioRepository.DeletarAsync(usuario);
            return retorno;
        }

        public async Task<ResponseDto<RetornoDadosLoginDto>> EfetuarLoginAsync(LoginDto usuario)
        {
            var response = new ResponseDto<RetornoDadosLoginDto>();

            if (string.IsNullOrEmpty(usuario.Email))
            {
                response.MensagensDeErros.Add("Obrigatório informar E-mail");
                response.Sucesso = false;
                return response;
            }

            if (string.IsNullOrEmpty(usuario.Senha))
            {
                response.MensagensDeErros.Add("Obrigatório informar Senha.");
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

            var usuarioDto = _mapper.Map<RetornoDadosLoginDto>(usuarioEntity);
            usuarioDto.Token = GerarJwt(usuarioEntity);
            response.result = usuarioDto;
            response.Sucesso = true;

            return response;
        }

        public async Task<ResponseDto<IList<UsuarioDto>>> ListarTodosUsuariosAsync(int qtdPorPag = 10, int pag = 1)
        {
            var retorno = new ResponseDto<IList<UsuarioDto>>();
            var dados = await _usuarioRepository.ConsultaPaginadaAsync(null, qtdPorPag, pag);
            if (dados.items.Any())
            {
                retorno.result = _mapper.Map<IList<UsuarioDto>>(dados.items);
                retorno.TotalDeRegistros = dados.registros;
                retorno.TotalDePaginas = Convert.ToInt32(dados.total);
                retorno.Sucesso = true;
                return retorno;
            }

            retorno.MensagensDeErros.Add("Nenhum usuário encontrado.");
            retorno.Sucesso = false;
            return retorno;
        }

        public async Task<ResponseDto<IList<UsuarioDto>>> ListarTodosUsuariosAsync(string nome, int qtdPorPag = 10, int pag = 1)
        {
            var retorno = new ResponseDto<IList<UsuarioDto>>();
            var dados = await _usuarioRepository.ConsultaPaginadaAsync(p => p.Nome.ToLower().Contains(nome.ToLower()), qtdPorPag, pag);
            if (dados.items.Any())
            {
                retorno.result = _mapper.Map<IList<UsuarioDto>>(dados.items);
                retorno.TotalDeRegistros = dados.registros;
                retorno.TotalDePaginas = Convert.ToInt32(dados.total);
                retorno.Sucesso = true;
                return retorno;
            }

            retorno.MensagensDeErros.Add("Nenhum usuário encontrado.");
            retorno.Sucesso = false;
            return retorno;
        }

        private string GerarJwt(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Role,usuario.Perfil.ToString()),
                    new Claim(ClaimTypes.Email,usuario.Email),
                    new Claim(ClaimTypes.Name,usuario.Nome)

                }),
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Expires = DateTime.UtcNow.AddHours((double)_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });
            var encodedToken = tokenHandler.WriteToken(token);
            return encodedToken;
        }

        public async Task<ResponseDto<UsuarioDto>> GerarCodigoParaResetarSenhaAsync(string email)
        {
            var retorno = new ResponseDto<UsuarioDto>();

            if (string.IsNullOrWhiteSpace(email))
            {
                retorno.Sucesso = false;
                retorno.MensagensDeErros.Add("Obrigatório informar e-mail");
                return retorno;
            }

            var usuario = await _usuarioRepository.RecuperarEmailAsync(email);
            if (usuario is null)
            {
                retorno.Sucesso = false;
                retorno.MensagensDeErros.Add("e-mail não existe");
                return retorno;
            }
            usuario.CodigoRecuperarSenha = new Random().Next(100000, 9999999);
            await _emailService.EnviarEmail(usuario.Email, "Recuperar Senha", GerarMensagem(usuario?.CodigoRecuperarSenha));


            retorno.Sucesso = await _usuarioRepository.AlterarAsync(usuario);
            return retorno;
        }

        private string GerarMensagem(int? valor)
        {
            var mensagem = $"Código para criar nova senha <b>{valor}</b>.";
            return mensagem;
        }

        public async Task<ResponseDto<UsuarioDto>> ResetarSenhaAsync(ResetarSenhaDto dados)
        {
            var retorno = new ResponseDto<UsuarioDto>();

            if (string.IsNullOrWhiteSpace(dados.Email))
            {
                retorno.Sucesso = false;
                retorno.MensagensDeErros.Add("Obrigatório informar e-mail");
                return retorno;
            }

            if (string.IsNullOrWhiteSpace(dados.SenhaNova))
            {
                retorno.Sucesso = false;
                retorno.MensagensDeErros.Add("Senha é obrigatória");
                return retorno;
            }

            if (string.IsNullOrWhiteSpace(dados.ConfirmacaoSenha))
            {
                retorno.Sucesso = false;
                retorno.MensagensDeErros.Add("Confirmação de senha é obrigatória.");
                return retorno;
            }

            if (dados.SenhaNova != dados.ConfirmacaoSenha)
            {
                retorno.Sucesso = false;
                retorno.MensagensDeErros.Add("as senhas são diferentes. A senha e a Confirmação de senha devem ser iguais.");
                return retorno;
            }

            var usuario = await _usuarioRepository.RecuperarUsuariosPorCodigoAsync(dados.CodigoResetarSenha, dados.Email);
            if (usuario is null)
            {
                retorno.Sucesso = false;
                retorno.MensagensDeErros.Add($"Código de recuperar senha não existe para o e-mail {dados.Email}.");
                return retorno;
            }

            usuario.Senha = dados.SenhaNova;
            usuario.CodigoRecuperarSenha = null;
            retorno.Sucesso = await _usuarioRepository.AlterarAsync(usuario);
            return retorno;
        }
    }
}
