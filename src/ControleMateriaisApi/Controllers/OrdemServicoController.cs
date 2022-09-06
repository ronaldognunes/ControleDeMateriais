using ControleMateriaisApi.Dto;
using ControleMateriaisApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleMateriaisApi.Controllers
{
    [Route("api/[controller]")]    
    public class OrdemServicoController : MainController
    {
        private readonly IOrdemServicoService _service;

        public OrdemServicoController(IOrdemServicoService service)
        {
            _service = service;
        }

        [HttpGet("retornar-todos-entrada")]
        [ProducesResponseType(typeof(ResponseDto<IList<OrdemServicoDto>>), 200)]
        [ProducesResponseType(typeof(ResponseDto<IList<OrdemServicoDto>>), 400)]
        public async Task<IActionResult> ListarTodasEntradasAsync()
        {
            var retorno = await _service.ListarTodasOsAsync();
            if (!retorno.Sucesso)
                return BadRequest(retorno);

            return Ok(retorno);
        }

        [HttpGet("consultar-entrada-por-id/{id}")]
        [ProducesResponseType(typeof(ResponseDto<OrdemServicoDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<OrdemServicoDto>), 400)]
        public async Task<IActionResult> ConsultarEntradaPorIdAsync(int id)
        {            
            var retorno = await _service.ConsultarOsPorIdAsync(id);
            if (!retorno.Sucesso)
                return BadRequest(retorno);

            return Ok(retorno);
        }

        [HttpPost("cadastrar-entrada")]
        [ProducesResponseType(typeof(ResponseDto<OrdemServicoDto>), 201)]
        [ProducesResponseType(typeof(ResponseDto<OrdemServicoDto>), 400)]
        public async Task<IActionResult> CadastrarEntradaAsync([FromBody] OrdemServicoDto entrada)
        {            
            var retorno = await _service.CadastrarOsAsync(entrada);
            if (!retorno.Sucesso)
                return BadRequest(retorno);

            return Created("", retorno);
        }

        [HttpPut("alterar-entrada/{id}")]
        [ProducesResponseType(typeof(ResponseDto<OrdemServicoDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<OrdemServicoDto>), 400)]
        public async Task<IActionResult> AlterarEntradaAsync(int id, [FromBody] OrdemServicoDto entrada)
        {            
            var retorno = await _service.AlterarOsAsync(id, entrada);
            if (!retorno.Sucesso)
                return BadRequest(retorno);

            return Ok(retorno);
        }

        [HttpDelete("excluir-entrada/{id}")]
        [ProducesResponseType(typeof(ResponseDto<OrdemServicoDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<OrdemServicoDto>), 400)]
        public async Task<IActionResult> DeletarEntradaAsync(int id)
        {            
            var retorno = await _service.DeletarOsAsync(id);
            if (!retorno.Sucesso)
                return BadRequest(retorno);

            return Ok(retorno);
        }
    }
}
