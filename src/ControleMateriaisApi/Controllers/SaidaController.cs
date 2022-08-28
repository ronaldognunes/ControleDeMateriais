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
        public async Task<ResponseDto<IList<SaidaDto>>> ListarTodasSaidaAsync()
        {
            return await _service.ListarTodasSaidaAsync();
        }

        [HttpGet("consultar-saidas-por-id/{id}")]
        public async Task<ResponseDto<SaidaDto>> ConsultarSaidaPorIdAsync(int id)
        {
            return await _service.ConsultarSaidaPorIdAsync(id);
        }

        [HttpPost("cadastrar-saida")]
        public async Task<ResponseDto<SaidaDto>> CadastrarSaidalAsync([FromBody] SaidaDto saida)
        {
            return await _service.CadastrarSaidalAsync(saida);
        }

        [HttpPut("alterar-saida/{id}")]
        public async Task<ResponseDto<SaidaDto>> AlterarSaidaAsync(int id, [FromBody] SaidaDto saida)
        {
            return await _service.AlterarSaidaAsync(id, saida);
        }

        [HttpDelete("excluir-saida/{id}")]
        public async Task<ResponseDto<SaidaDto>> DeletarSaidaAsync(int id)
        {
            return await _service.DeletarSaidaAsync(id);
        }
    }
}
