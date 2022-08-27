using ControleMateriaisApi.Dto;
using ControleMateriaisApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleMateriaisApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class MaterialController : MainController
    {
        private readonly IMaterialService _materialService;

        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }
        
        [HttpGet("retornar-todos-materiais")]
        public async Task<ResponseDto<IList<MaterialDto>>> ListarTodosMateriaisAsync()
        {
            return await _materialService.ListarTodosMateriaisAsync();
        }

        [HttpGet("consultar-material-por-id/{id}")]
        public async Task<ResponseDto<MaterialDto>> ConsultarMaterialPorIdAsync(int id)
        {
            return await _materialService.ConsultarMaterialPorIdAsync(id);
        }      

        [HttpPost("cadastrar-material")]
        public async Task<ResponseDto<MaterialDto>> CadastrarMaterialAsync([FromBody] MaterialDto material)
        {
            return await _materialService.CadastrarMaterialAsync(material);
        }

        [HttpPut("alterar-material/{id}")]
        public async Task<ResponseDto<MaterialDto>> AlterarMaterialAsync(int id, [FromBody] MaterialDto material)
        {
            return await _materialService.AlterarMaterialAsync(id, material);
        }

        [HttpDelete("excluir-material/{id}")]
        public async Task<ResponseDto<MaterialDto>> ExcluirMaterialAsync(int id)
        {
            return await _materialService.DeletarMaterialAsync(id);
        }
    }
}
