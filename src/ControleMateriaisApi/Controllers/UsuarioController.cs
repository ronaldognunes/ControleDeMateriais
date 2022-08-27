using ControleMateriaisApi.Dto;
using ControleMateriaisApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleMateriaisApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class UsuarioController : MainController
    {
        
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        
        [HttpGet("retornar-todos-usuarios")]
        public async Task<ResponseDto<IList<UsuarioDto>>> ListarTodosUsuariosAsync()
        {
            return await _usuarioService.ListarTodosUsuariosAsync();
        }
        
        [HttpGet("consultar-usuario-por-id/{id}")]
        public async Task<ResponseDto<UsuarioDto>> ConsultarUsuarioPorIdAsync(int id)
        {
            return await _usuarioService.ConsultarUsuariosPorIdAsync(id);
        }

        [HttpPost("efetuar-login")]
        [AllowAnonymous]
        public async Task<ResponseDto<UsuarioDto>> EfetuarLoginAsync([FromBody] UsuarioDto usuario)
        {
            return await _usuarioService.EfetuarLoginAsync(usuario);
        }

        [HttpPost("cadastrar-usuario")]
        [AllowAnonymous]
        public async Task<ResponseDto<UsuarioDto>> CadastrarUsuarioAsync([FromBody] UsuarioDto usuario)
        {
            return await _usuarioService.CadastrarUsuarioAsync(usuario);
        }
        
        [HttpPut("alterar-usuario/{id}")]
        public async Task<ResponseDto<UsuarioDto>> AlterarUsuarioAsync(int id, [FromBody] UsuarioDto usuario)
        {
            return await _usuarioService.AlterarUsuarioAsync(id, usuario);
        }
        
        [HttpDelete("excluir-usuario/{id}")]
        public async Task<ResponseDto<UsuarioDto>> ExcluirUsuarioAsync([FromBody] UsuarioDto usuario)
        {
            return await _usuarioService.DeletarUsuarioAsync(usuario);
        }
    }
}
