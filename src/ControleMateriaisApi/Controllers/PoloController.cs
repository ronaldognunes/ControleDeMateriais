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
        public async Task<ResponseDto<IList<PoloDto>>> ListarTodosPoloAsync()
        {
            return await _service.ListarTodosPoloAsync();
        }

        [HttpGet("consultar-polo-por-id/{id}")]
        public async Task<ResponseDto<PoloDto>> ConsultarPoloPorIdAsync(int id)
        {
            return await _service.ConsultarPoloPorIdAsync(id);
        }

        [HttpPost("cadastrar-polo")]
        public async Task<ResponseDto<PoloDto>> CadastrarPololAsync([FromBody] PoloDto saida)
        {
            return await _service.CadastrarPololAsync(saida);
        }

        [HttpPut("alterar-polo/{id}")]
        public async Task<ResponseDto<PoloDto>> AlterarPoloAsync(int id, [FromBody] PoloDto saida)
        {
            return await _service.AlterarPoloAsync(id, saida);
        }

        [HttpDelete("excluir-polo/{id}")]
        public async Task<ResponseDto<PoloDto>> DeletarPoloAsync(int id)
        {
            return await _service.DeletarPoloAsync(id);
        }
    }
}
