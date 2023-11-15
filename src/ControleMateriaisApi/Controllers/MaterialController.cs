using ControleMateriaisApi.Dto;
using ControleMateriaisApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleMateriaisApi.Controllers
{
    /// <summary>
    /// Rota possui métodos para controle de materiais
    /// </summary>
    [Route("api/[controller]")]
    
    public class MaterialController : MainController
    {
        private readonly IMaterialService _materialService;

        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }
        /// <summary>
        /// Retorna todos os materiais
        /// </summary>
        /// <param name="qtdPorPagina">quantidade por página</param>
        /// <param name="pagina"> página</param>
        /// <param name="nome">nome material</param>
        /// <returns></returns>
        [HttpGet("retornar-todos-materiais")]
        [ProducesResponseType(typeof(ResponseDto<MaterialDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<MaterialDto>), 400)]
        public async Task<IActionResult> ListarTodosMateriaisAsync(int qtdPorPagina = 10, int pagina = 1, string nome = "")
        {
            try
            {
                var retorno = new ResponseDto<IList<MaterialDto>> ();
                if (string.IsNullOrWhiteSpace(nome))
                    retorno = await _materialService.ListarTodosMateriaisAsync(qtdPorPagina,pagina);
                else
                    retorno = await _materialService.ListarTodosMateriaisAsync(nome,qtdPorPagina,pagina);

                if (!retorno.Sucesso)
                    return BadRequest(retorno);
                
                return Ok(retorno);
            }
            catch
            {
                return ErroDesconhecido();
            }

        }

        /// <summary>
        /// Consulta material por id
        /// </summary>
        /// <param name="id"> id do material</param>
        /// <returns></returns>    
        [HttpGet("consultar-material-por-id/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MaterialDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<MaterialDto>), 400)]
        public async Task<IActionResult> ConsultarMaterialPorIdAsync(int id)
        {
            try
            {
                var retorno = await _materialService.ConsultarMaterialPorIdAsync(id);
                if (!retorno.Sucesso)
                    return BadRequest(retorno);

                return Ok(retorno);
            }
            catch
            {
                return ErroDesconhecido();
            }
        }

        /// <summary>
        /// Cadastra material
        /// </summary>
        /// <param name="material"> json do material</param>
        /// <returns></returns>
        [HttpPost("cadastrar-material")]
        [ProducesResponseType(typeof(ResponseDto<MaterialDto>), 201)]
        [ProducesResponseType(typeof(ResponseDto<MaterialDto>), 400)]
        public async Task<IActionResult> CadastrarMaterialAsync([FromBody] CadastroMaterialDto material)
        {
            try
            {
                var retorno = await _materialService.CadastrarMaterialAsync(material);
                if (!retorno.Sucesso)
                    return BadRequest(retorno);

                return Created("", retorno);
            }
            catch
            {
                return ErroDesconhecido();
            }
        }

        /// <summary>
        ///  Alterar material
        /// </summary>
        /// <param name="id"> id material</param>
        /// <param name="material"> json material</param>
        /// <returns></returns>
        [HttpPut("alterar-material/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MaterialDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<MaterialDto>), 400)]
        public async Task<IActionResult> AlterarMaterialAsync(int id, [FromBody] MaterialDto material)
        {
            try
            {
                var retorno = await _materialService.AlterarMaterialAsync(id, material);
                if (!retorno.Sucesso)
                    return BadRequest(retorno);

                return Ok(retorno);
            }
            catch
            {
                return ErroDesconhecido();
            }
        }

        /// <summary>
        /// Excluir um material
        /// </summary>
        /// <param name="id">id material</param>
        /// <returns></returns>
        [HttpDelete("excluir-material/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MaterialDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<MaterialDto>), 400)]
        public async Task<IActionResult> ExcluirMaterialAsync(int id)
        {
            try
            {
                var retorno = await _materialService.DeletarMaterialAsync(id);
                if (!retorno.Sucesso)
                    return BadRequest(retorno);

                return Ok(retorno);
            }
            catch
            {
                return ErroDesconhecido();
            }
        }
    }
}
