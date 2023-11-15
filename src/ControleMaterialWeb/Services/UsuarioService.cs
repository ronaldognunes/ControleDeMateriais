using ControleMaterialWeb.Autenticacao;
using ControleMaterialWeb.Models;
using ControleMaterialWeb.Models.Usuario;
using ControleMaterialWeb.Services.Interfaces;

namespace ControleMaterialWeb.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IHttpServices _httpServices;
        private readonly IUsuarioLocalStorage _localStorage;
        private readonly TokenAutehtication _tokenAutehtication;
        private const string URI = "api/Usuario/";
        public UsuarioService(IHttpServices httpService, 
               IUsuarioLocalStorage localStorage,
               TokenAutehtication tokenAutehtication
            )
        {
            _httpServices = httpService;
            _localStorage = localStorage;
            _tokenAutehtication = tokenAutehtication;
        }
    
        public async Task<ResponseDto<UsuarioDto>> AlterarUsuarioAsync(int id, UsuarioDto usuario)
        {
            try
            {
                return await _httpServices.HttpPutAsync<UsuarioDto,ResponseDto<UsuarioDto>>($"{URI}alterar-usuario/{id}", usuario);                
            }
            catch(Exception ex) 
            {
                return new ResponseDto<UsuarioDto>() { Result = new UsuarioDto(), MensagensDeErros = new List<string>() { ex.Message}, Sucesso = false };
            }
        }

        public async Task<ResponseDto<UsuarioDto>> ApagarUsuarioAsync(int id)
        {
            try
            {
                return await _httpServices.HttpDeleteAsync<ResponseDto<UsuarioDto>>($"{URI}excluir-usuario/{id}");                
            }
            catch (Exception ex)
            {
                return new ResponseDto<UsuarioDto>() { Result = new UsuarioDto(), MensagensDeErros = new List<string>() { ex.Message }, Sucesso = false };
            }
        }

        public async Task<ResponseDto<UsuarioDto>> EfetuarLoginAsync(UsuarioLogin usuario)
        {
            try
            {
                var response = await _httpServices.HttpPostAsync<UsuarioLogin,ResponseDto<UsuarioDto>>($"{URI}efetuar-login", usuario);
                if (response.Sucesso)
                {                  
                    await _localStorage.SalvarDadosUsuario(response.Result);
                    await _tokenAutehtication.Login();
                }
                return response;
            }
            catch (Exception ex)
            {
                return new ResponseDto<UsuarioDto>() { Result = new UsuarioDto(), MensagensDeErros = new List<string>() { ex.Message }, Sucesso = false };
            }
        }

        public async Task<ResponseDto<UsuarioDto>> InserirNovoUsuarioAsync(CadastroUsuarioDto usuario)
        {
            try
            {
                var response = await _httpServices.HttpPostAsync<CadastroUsuarioDto,ResponseDto<UsuarioDto>>($"{URI}cadastrar-usuario", usuario);
                if (response.Sucesso)               
                    await _localStorage.SalvarDadosUsuario(response.Result);                                    
                    
                return response;
            }
            catch (Exception ex)
            {
                return new ResponseDto<UsuarioDto>() { Result = new UsuarioDto(), MensagensDeErros = new List<string>() { ex.Message }, Sucesso = false };
            }
        }        

        public async Task<ResponseDto<IList<UsuarioDto>>> RecuperarTodosUsuariosAsync(string nome = "", int qtdPorPaginas = 10, int pagina = 1)
        {
            try
            {
                var response = new ResponseDto<IList<UsuarioDto>>();
                if(string.IsNullOrWhiteSpace(nome))
                    response = await _httpServices.HttpGetAsync<ResponseDto<IList<UsuarioDto>>>($"{URI}retornar-todos-usuarios?qtdPorPagina={qtdPorPaginas}&pagina={pagina}");
                else
                    response = await _httpServices.HttpGetAsync<ResponseDto<IList<UsuarioDto>>>($"{URI}retornar-todos-usuarios?qtdPorPagina={qtdPorPaginas}&pagina={pagina}&nome={nome}");
                

                return response;
            }
            catch (Exception ex ) 
            {
                return new ResponseDto<IList<UsuarioDto>>() { Result = new List<UsuarioDto>(), MensagensDeErros = new List<string>() { ex.Message }, Sucesso = false };                
            }
        }

        public async Task<ResponseDto<UsuarioDto>> RecuperarUsuarioAsync(int id)
        {
            try
            {
                return await _httpServices.HttpGetAsync<ResponseDto<UsuarioDto>>($"{URI}consultar-usuario-por-id/{id}");
            }
            catch(Exception ex) 
            {
                return new ResponseDto<UsuarioDto>() { Result = new UsuarioDto(), MensagensDeErros = new List<string>() { ex.Message }, Sucesso = false };
            }
        }

        public async Task<ResponseDto<UsuarioDto>> ResetarSenhaAsync(ResetarSenhaDto usuario)
        {
            try
            {
                return await _httpServices.HttpPostAsync<ResetarSenhaDto,ResponseDto<UsuarioDto>>($"{URI}resetar-senha/", usuario);                
            }
            catch(Exception ex)
            {
                return new ResponseDto<UsuarioDto>() { Result = new UsuarioDto(), MensagensDeErros = new List<string>() { ex.Message }, Sucesso = false };
            }
        }

        public async Task<ResponseDto<UsuarioDto>> LembrarSenha(string email)
        {
            try
            {
                return await _httpServices.HttpPostAsync<string,ResponseDto<UsuarioDto>>($"{URI}enviar-email-resetar-senha/{email}","");                              
            }
            catch (Exception ex)
            {
                return new ResponseDto<UsuarioDto>() { Result = new UsuarioDto(), MensagensDeErros = new List<string>() { ex.Message }, Sucesso = false };
            }
        }
    }
}
