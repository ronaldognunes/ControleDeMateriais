using ControleMateriaisApi.Dto;
using ControleMateriaisApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleMateriaisApi.Controllers
{
    /// <summary>
    /// Rota com Métodos de controle do usuário e autenticação
    /// </summary>
    [Route("api/[controller]")]    
    public class UsuarioController : MainController
    {

        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        /// <summary>
        /// Retornar todos os usuários consulta páginada
        /// </summary>
        /// <param name="qtdPorPagina">quantidade por página</param>
        /// <param name="pagina">página</param>
        /// <param name="nome">nome usuário</param>
        /// <returns></returns>
        [HttpGet("retornar-todos-usuarios")]
        [ProducesResponseType(typeof(ResponseDto<IList<UsuarioDto>>), 200)]
        [ProducesResponseType(typeof(ResponseDto<IList<UsuarioDto>>), 400)]
        public async Task<IActionResult> ListarTodosUsuariosAsync(int qtdPorPagina = 10, int pagina = 1, string nome = "")
        {
            try
            {
                var retorno = new ResponseDto<IList<UsuarioDto>>();
                if (string.IsNullOrWhiteSpace(nome))
                    retorno = await _usuarioService.ListarTodosUsuariosAsync(qtdPorPagina, pagina);
                else
                    retorno = await _usuarioService.ListarTodosUsuariosAsync(nome,qtdPorPagina, pagina);    
                    
                if (!retorno.Sucesso)
                    return BadRequest(retorno);

                return Ok(retorno);
            }
            catch
            {
                return ErroDesconhecido();
            }

        }

        /// <summary>
        /// Consulta usuário por id
        /// </summary>
        /// <param name="id">Id do usuário</param>
        /// <returns></returns>
        [HttpGet("consultar-usuario-por-id/{id}")]
        [ProducesResponseType(typeof(ResponseDto<UsuarioDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<UsuarioDto>), 400)]
        public async Task<IActionResult> ConsultarUsuarioPorIdAsync(int id)
        {
            try
            {
                var retorno = await _usuarioService.ConsultarUsuariosPorIdAsync(id);
                if (!retorno.Sucesso)
                    return BadRequest(retorno);
                return Ok(retorno);
            }
            catch
            {
                return ErroDesconhecido();
            }

        }

        /// <summary>
        /// Efetuar o Login
        /// </summary>
        /// <param name="usuario">Json do login</param>
        /// <returns></returns>
        [HttpPost("efetuar-login")]
        [ProducesResponseType(typeof(ResponseDto<RetornoDadosLoginDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<RetornoDadosLoginDto>), 400)]
        [AllowAnonymous]
        public async Task<IActionResult> EfetuarLoginAsync([FromBody] LoginDto usuario)
        {
            try
            {
                var retorno = await _usuarioService.EfetuarLoginAsync(usuario);
                if (!retorno.Sucesso)
                    return BadRequest(retorno);
                return Ok(retorno);
            }
            catch
            {
                return ErroDesconhecido();
            }

        }

        /// <summary>
        /// Cadastrar usuário
        /// </summary>
        /// <param name="usuario">json usuário</param>
        /// <returns></returns>
        [HttpPost("cadastrar-usuario")]
        [ProducesResponseType(typeof(ResponseDto<UsuarioDto>), 201)]
        [ProducesResponseType(typeof(ResponseDto<UsuarioDto>), 400)]
        [AllowAnonymous]
        public async Task<IActionResult> CadastrarUsuarioAsync([FromBody] UsuarioCadastroDto usuario)
        {
            try
            {
                var retorno = await _usuarioService.CadastrarUsuarioAsync(usuario);
                if (!retorno.Sucesso)
                    return BadRequest(retorno);
                return Created("", retorno);
            }
            catch
            {
                return ErroDesconhecido();
            }

        }

        /// <summary>
        /// Alterar Usuario
        /// </summary>
        /// <param name="id">Id usuário</param>
        /// <param name="usuario">json usuario</param>
        /// <returns></returns>
        [HttpPut("alterar-usuario/{id}")]
        [ProducesResponseType(typeof(ResponseDto<UsuarioDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<UsuarioDto>), 400)]
        public async Task<IActionResult> AlterarUsuarioAsync(int id, [FromBody] AlteracaoUsuarioDto usuario)
        {
            try
            {
                var retorno = await _usuarioService.AlterarUsuarioAsync(id, usuario);
                if (!retorno.Sucesso)
                    return BadRequest(retorno);
                return Ok(retorno);
            }
            catch
            {
                return ErroDesconhecido();
            }

        }

        /// <summary>
        /// Excluir usuário
        /// </summary>
        /// <param name="id">Id usuário</param>
        /// <returns></returns>
        [HttpDelete("excluir-usuario/{id}")]
        [ProducesResponseType(typeof(ResponseDto<UsuarioDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<UsuarioDto>), 400)]
        public async Task<IActionResult> ExcluirUsuarioAsync([FromRoute] int id)
        {
            try
            {
                var retorno = await _usuarioService.DeletarUsuarioAsync(id);
                if (!retorno.Sucesso)
                    return BadRequest(retorno);
                return Ok(retorno);
            }
            catch
            {
                return ErroDesconhecido();
            }

        }

        /// <summary>
        /// Enviar e-mail usuário com código para resetar senha
        /// </summary>
        /// <param name="email">email do usuário</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("enviar-email-resetar-senha/{email}")]
        [ProducesResponseType(typeof(ResponseDto<UsuarioDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<UsuarioDto>), 400)]
        public async Task<IActionResult> EnviarEmailResetarSenhaAsync([FromRoute] string email)
        {
            try
            {
                var retorno = await _usuarioService.GerarCodigoParaResetarSenhaAsync(email);
                if (!retorno.Sucesso)
                    return BadRequest(retorno);
                return Ok(retorno);
            }
            catch
            {
                return ErroDesconhecido();
            }

        }

        /// <summary>
        /// Resetar a senha do usuário
        /// </summary>
        /// <param name="dados">json com dados para resetar senha</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("resetar-senha")]
        [ProducesResponseType(typeof(ResponseDto<UsuarioDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<UsuarioDto>), 400)]
        public async Task<IActionResult> ResetarSenhaAsync(ResetarSenhaDto dados)
        {
            try
            {
                var retorno = await _usuarioService.ResetarSenhaAsync(dados);
                if (!retorno.Sucesso)
                    return BadRequest(retorno);
                return Ok(retorno);
            }
            catch
            {
                return ErroDesconhecido();
            }

        }
    }
}
