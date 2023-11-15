using ControleMateriaisApi.Dto;
using ControleMateriaisApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleMateriaisApi.Controllers
{
    /// <summary>
    /// Roda possui métodos de controle do Polo
    /// </summary>
    [Route("api/[controller]")]    
    [Authorize(Roles = "Administrador,Gerente")]
    
    public class PoloController : MainController
    {
        private readonly IPoloService _service;
        public PoloController(IPoloService poloService)
        {
            _service = poloService;
        }
        /// <summary>
        /// Retornar Polos Consulta paginada
        /// </summary>
        /// <param name="qtdPorPagina">quantidade por página</param>
        /// <param name="pagina">página</param>
        /// <param name="nome">nome do polo</param>
        /// <returns></returns>
        [HttpGet("retornar-todas-polos")]
        [ProducesResponseType(typeof(ResponseDto<PoloDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<PoloDto>), 400)]
        public async Task<IActionResult> ListarTodosPoloAsync(int qtdPorPagina = 10, int pagina = 1, string nome ="")
        {
            try
            {
                var retorno = new ResponseDto<IList<PoloDto>>();
                if(string.IsNullOrWhiteSpace(nome))
                    retorno = await _service.ListarTodosPoloAsync(qtdPorPagina,pagina);
                else
                    retorno = await _service.ListarTodosPoloAsync(nome,qtdPorPagina,pagina);

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
        /// Consultar Polo
        /// </summary>
        /// <param name="id">Id do Polo</param>
        /// <returns></returns>
        [HttpGet("consultar-polo-por-id/{id}")]
        [ProducesResponseType(typeof(ResponseDto<PoloDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<PoloDto>), 400)]
        public async Task<IActionResult> ConsultarPoloPorIdAsync(int id)
        {
            try
            {
                var retorno = await _service.ConsultarPoloPorIdAsync(id);
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
        /// Cadastrar Polo
        /// </summary>
        /// <param name="saida">json do polo</param>
        /// <returns></returns>
        [HttpPost("cadastrar-polo")]
        [ProducesResponseType(typeof(ResponseDto<PoloDto>), 201)]
        [ProducesResponseType(typeof(ResponseDto<PoloDto>), 400)]
        public async Task<IActionResult> CadastrarPololAsync([FromBody] CadastroPoloDto saida)
        {
            try
            {
                var retorno = await _service.CadastrarPololAsync(saida);
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
        /// Alterar Polo
        /// </summary>
        /// <param name="id">Id do Polo</param>
        /// <param name="saida">json do Polo</param>
        /// <returns></returns>    
        [HttpPut("alterar-polo/{id}")]
        [ProducesResponseType(typeof(ResponseDto<PoloDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<PoloDto>), 400)]
        public async Task<IActionResult> AlterarPoloAsync(int id, [FromBody] PoloDto saida)
        {
            try
            {
                var retorno = await _service.AlterarPoloAsync(id, saida);
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
        /// Excluir Polo pelo Id
        /// </summary>
        /// <param name="id">Id do Polo</param>
        /// <returns></returns>
        [HttpDelete("excluir-polo/{id}")]
        [ProducesResponseType(typeof(ResponseDto<PoloDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<PoloDto>), 400)]
        public async Task<IActionResult> DeletarPoloAsync(int id)
        {
            try
            {
                var retorno = await _service.DeletarPoloAsync(id);
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
