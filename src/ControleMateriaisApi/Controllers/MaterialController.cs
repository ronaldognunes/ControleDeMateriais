using ControleMateriaisApi.Dto;
using ControleMateriaisApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        [ProducesResponseType(typeof(ResponseDto<MaterialDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<MaterialDto>), 400)]
        public async Task<IActionResult> ListarTodosMateriaisAsync()
        {            
            var retorno = await _materialService.ListarTodosMateriaisAsync();
            if (!retorno.Sucesso)
                return BadRequest(retorno);

            return Ok(retorno);
        }

        [HttpGet("consultar-material-por-id/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MaterialDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<MaterialDto>), 400)]
        public async Task<IActionResult> ConsultarMaterialPorIdAsync(int id)
        {            
            var retorno = await _materialService.ConsultarMaterialPorIdAsync(id);
            if (!retorno.Sucesso)
                return BadRequest(retorno);

            return Ok(retorno);
        }      

        [HttpPost("cadastrar-material")]
        [ProducesResponseType(typeof(ResponseDto<MaterialDto>), 201)]
        [ProducesResponseType(typeof(ResponseDto<MaterialDto>), 400)]
        public async Task<IActionResult> CadastrarMaterialAsync([FromBody] CadastroMaterialDto material)
        {            
            var retorno = await _materialService.CadastrarMaterialAsync(material);
            if (!retorno.Sucesso)
                return BadRequest(retorno);

            return Created("", retorno);
        }

        [HttpPut("alterar-material/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MaterialDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<MaterialDto>), 400)]
        public async Task<IActionResult> AlterarMaterialAsync(int id, [FromBody] MaterialDto material)
        {            
            var retorno = await _materialService.AlterarMaterialAsync(id, material);
            if (!retorno.Sucesso)
                return BadRequest(retorno);

            return Ok(retorno);
        }

        [HttpDelete("excluir-material/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MaterialDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<MaterialDto>), 400)]
        public async Task<IActionResult> ExcluirMaterialAsync(int id)
        {
            var retorno = await _materialService.DeletarMaterialAsync(id);
            if (!retorno.Sucesso)
                return BadRequest(retorno);

            return Ok(retorno);
        }
    }
}
