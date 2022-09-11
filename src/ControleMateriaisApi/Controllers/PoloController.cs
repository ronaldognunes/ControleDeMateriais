using ControleMateriaisApi.Dto;
using ControleMateriaisApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleMateriaisApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class PoloController : MainController
    {
        private readonly IPoloService _service;
        public PoloController(IPoloService poloService)
        {
            _service = poloService; 
        }
        [HttpGet("retornar-todas-polos")]
        [ProducesResponseType(typeof(ResponseDto<PoloDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<PoloDto>), 400)]
        public async Task<IActionResult> ListarTodosPoloAsync()
        {            
            var retorno = await _service.ListarTodosPoloAsync();
            if (!retorno.Sucesso)
                return BadRequest(retorno);

            return Ok(retorno);
        }

        [HttpGet("consultar-polo-por-id/{id}")]
        [ProducesResponseType(typeof(ResponseDto<PoloDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<PoloDto>), 400)]
        public async Task<IActionResult> ConsultarPoloPorIdAsync(int id)
        {            
            var retorno = await _service.ConsultarPoloPorIdAsync(id);
            if (!retorno.Sucesso)
                return BadRequest(retorno);

            return Ok(retorno);
        }

        [HttpPost("cadastrar-polo")]
        [ProducesResponseType(typeof(ResponseDto<PoloDto>), 201)]
        [ProducesResponseType(typeof(ResponseDto<PoloDto>), 400)]
        public async Task<IActionResult> CadastrarPololAsync([FromBody] CadastroPoloDto saida)
        {            
            var retorno = await _service.CadastrarPololAsync(saida);
            if (!retorno.Sucesso)
                return BadRequest(retorno);

            return Created("",retorno);
        }

        [HttpPut("alterar-polo/{id}")]
        [ProducesResponseType(typeof(ResponseDto<PoloDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<PoloDto>), 400)]
        public async Task<IActionResult> AlterarPoloAsync(int id, [FromBody] PoloDto saida)
        {            
            var retorno = await _service.AlterarPoloAsync(id, saida);
            if (!retorno.Sucesso)
                return BadRequest(retorno);

            return Ok(retorno);
        }

        [HttpDelete("excluir-polo/{id}")]
        [ProducesResponseType(typeof(ResponseDto<PoloDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<PoloDto>), 400)]
        public async Task<IActionResult> DeletarPoloAsync(int id)
        {            
            var retorno = await _service.DeletarPoloAsync(id);
            if (!retorno.Sucesso)
                return BadRequest(retorno);

            return Ok(retorno);
        }
    }
}
