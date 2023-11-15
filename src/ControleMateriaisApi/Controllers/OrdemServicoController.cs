using ControleMateriaisApi.Domain.Enum;
using ControleMateriaisApi.Dto;
using ControleMateriaisApi.Repository.Interfaces;
using ControleMateriaisApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleMateriaisApi.Controllers
{
    /// <summary>
    /// Rota possui métodos de controle de ordem de serviço
    /// </summary>
    [Route("api/[controller]")]
    
    public class OrdemServicoController : MainController
    {
        private readonly IOrdemServicoService _service;


        public OrdemServicoController(IOrdemServicoService service)
        {
            _service = service;
        }

        /// <summary>
        /// Gera relatório
        /// </summary>
        /// <param name="tipoOrdem"> Tipo de Ordem de Serviço</param>
        /// <param name="dataInicio"> data início </param>
        /// <param name="dataFim"> data fim </param>
        /// <returns></returns>
        [HttpGet("relatorio-os")]
        [ProducesResponseType(typeof(ResponseDto<ArquivoDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<ArquivoDto>), 400)]
        public async Task<IActionResult> GerarRelatorioAsync(TipoOrdemServico? tipoOrdem, DateTime? dataInicio, DateTime? dataFim)
        {
            try
            {
                var retorno = await _service.GerarRelatorioAsync(tipoOrdem, dataInicio, dataFim);
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
        /// Retornar todas as ordens de serviços cadastradas paginada
        /// </summary>
        /// <param name="qtdPorPagina">quantidade por página</param>
        /// <param name="pagina">página</param>
        /// <returns></returns>
        [HttpGet("retornar-todas-os")]
        [ProducesResponseType(typeof(ResponseDto<IList<OrdemServicoDto>>), 200)]
        [ProducesResponseType(typeof(ResponseDto<IList<OrdemServicoDto>>), 400)]
        public async Task<IActionResult> ListarTodasossAsync(int qtdPorPagina = 10, int pagina = 1, int os = 0)
        {
            try
            {
                var retorno = await _service.ListarTodasOsAsync(os,qtdPorPagina, pagina);
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
        /// Consultar Ordem de Serviço por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("consultar-os-por-id/{id}")]
        [ProducesResponseType(typeof(ResponseDto<RetornoOrdemServicoDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<RetornoOrdemServicoDto>), 400)]
        public async Task<IActionResult> ConsultarosPorIdAsync(int id)
        {
            try
            {
                var retorno = await _service.ConsultarOsPorIdAsync(id);
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
        /// Cadastrar Ordem de Serviço
        /// </summary>
        /// <param name="os">json da Ordem de serviço</param>
        /// <returns></returns>
        [HttpPost("cadastrar-os")]
        [ProducesResponseType(typeof(ResponseDto<OrdemServicoDto>), 201)]
        [ProducesResponseType(typeof(ResponseDto<OrdemServicoDto>), 400)]
        public async Task<IActionResult> CadastrarosAsync([FromBody] CadastroOrdemServicoDto os)
        {
            try
            {                
                var retorno = await _service.CadastrarOsAsync(os);

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
        /// Alterar ordem de serviço
        /// </summary>
        /// <param name="id">id da ordem de serviço</param>
        /// <param name="os">json ordem de serviço</param>
        /// <returns></returns>
        [HttpPut("alterar-os/{id}")]
        [ProducesResponseType(typeof(ResponseDto<OrdemServicoDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<OrdemServicoDto>), 400)]
        public async Task<IActionResult> AlterarosAsync(int id, [FromBody] AlteracaoOrdemServicoDto os)
        {
            try
            {
                var retorno = await _service.AlterarOsAsync(id, os);
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
        /// Excluir ordem de serviço
        /// </summary>
        /// <param name="id">id ordem de serviço</param>
        /// <returns></returns>
        [HttpDelete("excluir-os/{id}")]
        [ProducesResponseType(typeof(ResponseDto<OrdemServicoDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<OrdemServicoDto>), 400)]
        public async Task<IActionResult> DeletarosAsync(int id)
        {
            try
            {
                var retorno = await _service.DeletarOsAsync(id);
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
        /// Cadastrar Item da Ordem de Serviço
        /// </summary>
        /// <param name="os">json item da ordem de serviço</param>
        /// <returns></returns>
        [HttpPost("cadastrar-item-os")]
        [ProducesResponseType(typeof(ResponseDto<ItemOrdemServicoDto>), 201)]
        [ProducesResponseType(typeof(ResponseDto<ItemOrdemServicoDto>), 400)]
        public async Task<IActionResult> CadastrarItemOsAsync([FromBody] CadastroItemOrdemServicoDto os)
        {
            try
            {
                var retorno = await _service.CadastrarItemOsAsync(os);
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
        /// Cadastrar vários itens da Ordem de Serviço
        /// </summary>
        /// <param name="oss">json itens da ordem de serviço</param>
        /// <returns></returns>
        [HttpPost("cadastrar-varios-itens-os")]
        [ProducesResponseType(typeof(ResponseDto<ItemOrdemServicoDto>), 201)]
        [ProducesResponseType(typeof(ResponseDto<ItemOrdemServicoDto>), 400)]
        public async Task<IActionResult> CadastrarItemOsAsync([FromBody] IList<CadastroItemOrdemServicoDto> oss)
        {
            try
            {
                var retorno = await _service.CadastrarVariosItensOsAsync(oss);
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
        /// Alterar Item da Ordem de Serviço
        /// </summary>
        /// <param name="os">json item da ordem de serviço</param>
        /// <returns></returns>
        [HttpPut("alterar-item-os")]
        [ProducesResponseType(typeof(ResponseDto<ItemOrdemServicoDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<ItemOrdemServicoDto>), 400)]
        public async Task<IActionResult> AlterarItemOsAsync([FromBody] ItemOrdemServicoDto os)
        {
            try
            {
                var retorno = await _service.AlterarItemOsAsync(os);
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
        /// Exluir item ordem de serviço
        /// </summary>
        /// <param name="id">id do item da ordem de serviço</param>
        /// <returns></returns>
        [HttpDelete("excluir-item-os/{id}")]
        [ProducesResponseType(typeof(ResponseDto<ItemOrdemServicoDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<ItemOrdemServicoDto>), 400)]
        public async Task<IActionResult> DeletarItemOsAsync(int id)
        {
            try
            {
                var retorno = await _service.ApagarItemOsAsync(id);
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
        /// Retornar todos os itens da ordem de serviço
        /// </summary>
        /// <param name="id">id ordem de serviço</param>
        /// <param name="qtdPorPaginas">quantidade por páginas</param>
        /// <param name="pagina">página</param>
        /// <returns></returns>
        [HttpGet("retornar-todos-itens-da-os/{id:int}")]
        [ProducesResponseType(typeof(IList<ResponseDto<ItemOrdemServicoDto>>), 200)]
        [ProducesResponseType(typeof(IList<ResponseDto<ItemOrdemServicoDto>>), 400)]
        public async Task<IActionResult> RetornarTodosItensDaOs(int id,int qtdPorPaginas = 10, int pagina=1 )
        {
            try
            {
                var retorno = await _service.ListarTodasItensOsAsync(id,qtdPorPaginas,pagina);
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
