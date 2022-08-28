using ControleMateriaisApi.Dto;
using ControleMateriaisApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleMateriaisApi.Controllers
{
    [Route("api/[controller]")]    
    public class EntradaController : ControllerBase
    {
        private readonly IEntradaService _service;

        public EntradaController(IEntradaService service)
        {
            _service = service;
        }

        [HttpGet("retornar-todos-entrada")]
        public async Task<ResponseDto<IList<EntradaDto>>> ListarTodasEntradasAsync()
        {
            return await _service.ListarTodasEntradasAsync();
        }

        [HttpGet("consultar-entrada-por-id/{id}")]
        public async Task<ResponseDto<EntradaDto>> ConsultarEntradaPorIdAsync(int id)
        {
            return await _service.ConsultarEntradaPorIdAsync(id);
        }

        [HttpPost("cadastrar-entrada")]
        public async Task<ResponseDto<EntradaDto>> CadastrarEntradaAsync([FromBody] EntradaDto entrada)
        {
            return await _service.CadastrarEntradaAsync(entrada);
        }

        [HttpPut("alterar-entrada/{id}")]
        public async Task<ResponseDto<EntradaDto>> AlterarEntradaAsync(int id, [FromBody] EntradaDto entrada)
        {
            return await _service.AlterarEntradaAsync(id, entrada);
        }

        [HttpDelete("excluir-entrada/{id}")]
        public async Task<ResponseDto<EntradaDto>> DeletarEntradaAsync(int id)
        {
            return await _service.DeletarEntradaAsync(id);
        }
    }
}
