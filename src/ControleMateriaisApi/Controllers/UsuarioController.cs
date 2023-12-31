﻿using ControleMateriaisApi.Dto;
using ControleMateriaisApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleMateriaisApi.Controllers
{
    [Route("api/[controller]")]    
    public class UsuarioController : MainController
    {
        
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        
        [HttpGet("retornar-todos-usuarios")]
        [ProducesResponseType(typeof(ResponseDto<IList<UsuarioDto>>),200)]
        [ProducesResponseType(typeof(ResponseDto<IList<UsuarioDto>>), 400)]
        public async Task<IActionResult> ListarTodosUsuariosAsync()
        {
            var retorno = await _usuarioService.ListarTodosUsuariosAsync();
            if (!retorno.Sucesso)
                return BadRequest(retorno);

            return Ok(retorno);
        }
        
        [HttpGet("consultar-usuario-por-id/{id}")]
        [ProducesResponseType(typeof(ResponseDto<UsuarioDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<UsuarioDto>), 400)]
        public async Task<IActionResult> ConsultarUsuarioPorIdAsync(int id)
        {
            var retorno = await _usuarioService.ConsultarUsuariosPorIdAsync(id);
            if (!retorno.Sucesso)
                return BadRequest(retorno);
            return Ok(retorno);
        }

        [HttpPost("efetuar-login")]
        [ProducesResponseType(typeof(ResponseDto<UsuarioDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<UsuarioDto>), 400)]
        [AllowAnonymous]
        public async Task<IActionResult> EfetuarLoginAsync([FromBody] LoginDto usuario)
        {
            var retorno = await _usuarioService.EfetuarLoginAsync(usuario);            
            if (!retorno.Sucesso)
                return BadRequest(retorno);
            return Ok(retorno);
        }

        [HttpPost("cadastrar-usuario")]
        [ProducesResponseType(typeof(ResponseDto<UsuarioDto>), 201)]
        [ProducesResponseType(typeof(ResponseDto<UsuarioDto>), 400)]
        [AllowAnonymous]
        public async Task<IActionResult> CadastrarUsuarioAsync([FromBody] UsuarioCadastroDto usuario)
        {
            var retorno = await _usuarioService.CadastrarUsuarioAsync(usuario);             
            if (!retorno.Sucesso)
                return BadRequest(retorno);
            return Created("",retorno);
        }
        
        [HttpPut("alterar-usuario/{id}")]
        [ProducesResponseType(typeof(ResponseDto<UsuarioDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<UsuarioDto>), 400)]
        public async Task<IActionResult> AlterarUsuarioAsync(int id, [FromBody] UsuarioDto usuario)
        {            
            var retorno = await _usuarioService.AlterarUsuarioAsync(id, usuario);
            if (!retorno.Sucesso)
                return BadRequest(retorno);
            return Ok(retorno);
        }
        
        [HttpDelete("excluir-usuario/{id}")]
        [ProducesResponseType(typeof(ResponseDto<UsuarioDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<UsuarioDto>), 400)]
        public async Task<IActionResult> ExcluirUsuarioAsync([FromRoute]int id)
        {            
            var retorno = await _usuarioService.DeletarUsuarioAsync(id);
            if (!retorno.Sucesso)
                return BadRequest(retorno);
            return Ok(retorno);
        }

        [AllowAnonymous]
        [HttpPost("enviar-email-resetar-senha/{email}")]
        [ProducesResponseType(typeof(ResponseDto<UsuarioDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<UsuarioDto>), 400)]
        public async Task<IActionResult> EnviarEmailResetarSenhaAsync([FromRoute] string email)
        {
            var retorno = await _usuarioService.GerarCodigoParaResetarSenhaAsync(email);
            if (!retorno.Sucesso)
                return BadRequest(retorno);
            return Ok(retorno);
        }

        [AllowAnonymous]
        [HttpPost("resetar-senha")]
        [ProducesResponseType(typeof(ResponseDto<UsuarioDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<UsuarioDto>), 400)]
        public async Task<IActionResult> ResetarSenhaAsync(ResetarSenhaDto dados)
        {
            var retorno = await _usuarioService.ResetarSenhaAsync(dados);
            if (!retorno.Sucesso)
                return BadRequest(retorno);
            return Ok(retorno);
        }
    }
}
