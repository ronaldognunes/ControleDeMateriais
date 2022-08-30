using ControleMateriaisApi.Dto;
using ControleMateriaisApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleMateriaisApi.Controllers
{
    [Route("api/[controller]")]
    public class SaidaController : MainController
    {
        private readonly ISaidaService _service;

        public SaidaController(ISaidaService service)
        {
            _service = service;
        }

        [HttpGet("retornar-todas-saidas")]
        [ProducesResponseType(typeof(ResponseDto<SaidaDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<SaidaDto>), 400)]
        public async Task<IActionResult> ListarTodasSaidaAsync()
        {            
            var retorno = await _service.ListarTodasSaidaAsync();
            if (!retorno.Sucesso)
                return BadRequest(retorno);

            return Ok(retorno);
        }

        [HttpGet("consultar-saidas-por-id/{id}")]
        [ProducesResponseType(typeof(ResponseDto<SaidaDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<SaidaDto>), 400)]
        public async Task<IActionResult> ConsultarSaidaPorIdAsync(int id)
        {            
            var retorno = await _service.ConsultarSaidaPorIdAsync(id);
            if (!retorno.Sucesso)
                return BadRequest(retorno);

            return Ok(retorno);
        }

        [HttpPost("cadastrar-saida")]
        [ProducesResponseType(typeof(ResponseDto<SaidaDto>), 201)]
        [ProducesResponseType(typeof(ResponseDto<SaidaDto>), 400)]
        public async Task<IActionResult> CadastrarSaidalAsync([FromBody] SaidaDto saida)
        {            
            var retorno = await _service.CadastrarSaidalAsync(saida);
            if (!retorno.Sucesso)
                return BadRequest(retorno);

            return Created("",retorno);
        }

        [HttpPut("alterar-saida/{id}")]
        [ProducesResponseType(typeof(ResponseDto<SaidaDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<SaidaDto>), 400)]
        public async Task<IActionResult> AlterarSaidaAsync(int id, [FromBody] SaidaDto saida)
        {            
            var retorno = await _service.AlterarSaidaAsync(id, saida);
            if (!retorno.Sucesso)
                return BadRequest(retorno);

            return Ok(retorno);
        }

        [HttpDelete("excluir-saida/{id}")]
        [ProducesResponseType(typeof(ResponseDto<SaidaDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<SaidaDto>), 400)]
        public async Task<IActionResult> DeletarSaidaAsync(int id)
        {            
            var retorno = await _service.DeletarSaidaAsync(id);
            if (!retorno.Sucesso)
                return BadRequest(retorno);

            return Ok(retorno);
        }
    }
}
