using ControleMateriaisApi.Dto;
using ControleMateriaisApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleMateriaisApi.Controllers
{
    [Route("api/[controller]")]    
    public class EntradaController : MainController
    {
        private readonly IEntradaService _service;

        public EntradaController(IEntradaService service)
        {
            _service = service;
        }

        [HttpGet("retornar-todos-entrada")]
        [ProducesResponseType(typeof(ResponseDto<IList<EntradaDto>>), 200)]
        [ProducesResponseType(typeof(ResponseDto<IList<EntradaDto>>), 400)]
        public async Task<IActionResult> ListarTodasEntradasAsync()
        {
            var retorno = await _service.ListarTodasEntradasAsync();
            if (!retorno.Sucesso)
                return BadRequest(retorno);

            return Ok(retorno);
        }

        [HttpGet("consultar-entrada-por-id/{id}")]
        [ProducesResponseType(typeof(ResponseDto<EntradaDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<EntradaDto>), 400)]
        public async Task<IActionResult> ConsultarEntradaPorIdAsync(int id)
        {            
            var retorno = await _service.ConsultarEntradaPorIdAsync(id);
            if (!retorno.Sucesso)
                return BadRequest(retorno);

            return Ok(retorno);
        }

        [HttpPost("cadastrar-entrada")]
        [ProducesResponseType(typeof(ResponseDto<EntradaDto>), 201)]
        [ProducesResponseType(typeof(ResponseDto<EntradaDto>), 400)]
        public async Task<IActionResult> CadastrarEntradaAsync([FromBody] EntradaDto entrada)
        {            
            var retorno = await _service.CadastrarEntradaAsync(entrada);
            if (!retorno.Sucesso)
                return BadRequest(retorno);

            return Created("", retorno);
        }

        [HttpPut("alterar-entrada/{id}")]
        [ProducesResponseType(typeof(ResponseDto<EntradaDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<EntradaDto>), 400)]
        public async Task<IActionResult> AlterarEntradaAsync(int id, [FromBody] EntradaDto entrada)
        {            
            var retorno = await _service.AlterarEntradaAsync(id, entrada);
            if (!retorno.Sucesso)
                return BadRequest(retorno);

            return Ok(retorno);
        }

        [HttpDelete("excluir-entrada/{id}")]
        [ProducesResponseType(typeof(ResponseDto<EntradaDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<EntradaDto>), 400)]
        public async Task<IActionResult> DeletarEntradaAsync(int id)
        {            
            var retorno = await _service.DeletarEntradaAsync(id);
            if (!retorno.Sucesso)
                return BadRequest(retorno);

            return Ok(retorno);
        }
    }
}
