using ControleMateriaisApi.Domain.Enum;
using ControleMateriaisApi.Dto;
using ControleMateriaisApi.Repository.Interfaces;
using ControleMateriaisApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleMateriaisApi.Controllers
{
    [Route("api/[controller]")]    
    public class OrdemServicoController : MainController
    {
        private readonly IOrdemServicoService _service;
        private readonly IOrdemServicoRepository _repository;

        public OrdemServicoController(IOrdemServicoService service,
                                      IOrdemServicoRepository repository)
        {
            _service = service;
            _repository = repository;   
        }
       
        [HttpGet("relatorio-os")]
        [ProducesResponseType(typeof(ResponseDto<ArquivoDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<ArquivoDto>), 400)]
        public async Task<IActionResult> GerarRelatorioAsync(TipoOrdemServico? tipoOrdem, DateTime? dataInicio, DateTime? dataFim)
        {
            var retorno = await _service.GerarRelatorioAsync(tipoOrdem, dataInicio,dataFim);
            if (!retorno.Sucesso)
                return BadRequest(retorno);


            return Ok(retorno);
        }

        [HttpGet("retornar-todas-os")]
        [ProducesResponseType(typeof(ResponseDto<IList<OrdemServicoDto>>), 200)]
        [ProducesResponseType(typeof(ResponseDto<IList<OrdemServicoDto>>), 400)]
        public async Task<IActionResult> ListarTodasossAsync()
        {
            var retorno = await _service.ListarTodasOsAsync();
            if (!retorno.Sucesso)
                return BadRequest(retorno);

            return Ok(retorno);
        }

        [HttpGet("consultar-os-por-id/{id}")]
        [ProducesResponseType(typeof(ResponseDto<OrdemServicoDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<OrdemServicoDto>), 400)]
        public async Task<IActionResult> ConsultarosPorIdAsync(int id)
        {            
            var retorno = await _service.ConsultarOsPorIdAsync(id);
            if (!retorno.Sucesso)
                return BadRequest(retorno);

            return Ok(retorno);
        }

        [HttpPost("cadastrar-os")]
        [ProducesResponseType(typeof(ResponseDto<OrdemServicoDto>), 201)]
        [ProducesResponseType(typeof(ResponseDto<OrdemServicoDto>), 400)]
        public async Task<IActionResult> CadastrarosAsync([FromBody] CadastroOrdemServicoDto os)
        {            
            var retorno = await _service.CadastrarOsAsync(os);
            if (!retorno.Sucesso)
                return BadRequest(retorno);

            return Created("", retorno);
        }

        [HttpPut("alterar-os/{id}")]
        [ProducesResponseType(typeof(ResponseDto<OrdemServicoDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<OrdemServicoDto>), 400)]
        public async Task<IActionResult> AlterarosAsync(int id, [FromBody] OrdemServicoDto os)
        {            
            var retorno = await _service.AlterarOsAsync(id, os);
            if (!retorno.Sucesso)
                return BadRequest(retorno);

            return Ok(retorno);
        }

        [HttpDelete("excluir-os/{id}")]
        [ProducesResponseType(typeof(ResponseDto<OrdemServicoDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<OrdemServicoDto>), 400)]
        public async Task<IActionResult> DeletarosAsync(int id)
        {            
            var retorno = await _service.DeletarOsAsync(id);
            if (!retorno.Sucesso)
                return BadRequest(retorno);

            return Ok(retorno);
        }

        [HttpPost("cadastrar-item-os")]
        [ProducesResponseType(typeof(ResponseDto<OrdemServicoDto>), 201)]
        [ProducesResponseType(typeof(ResponseDto<OrdemServicoDto>), 400)]
        public async Task<IActionResult> CadastrarItemOsAsync([FromBody] CadastroItemOrdemServicoDto os)
        {
            var retorno = await _service.CadastrarItemOsAsync(os);
            if (!retorno.Sucesso)
                return BadRequest(retorno);

            return Created("", retorno);
        }

        [HttpPut("alterar-item-os")]
        [ProducesResponseType(typeof(ResponseDto<OrdemServicoDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<OrdemServicoDto>), 400)]
        public async Task<IActionResult> AlterarItemOsAsync([FromBody] ItemOrdemServicoDto os)
        {
            var retorno = await _service.AlterarItemOsAsync(os);
            if (!retorno.Sucesso)
                return BadRequest(retorno);

            return Ok(retorno);
        }

        [HttpDelete("excluir-item-os/{id}")]
        [ProducesResponseType(typeof(ResponseDto<OrdemServicoDto>), 200)]
        [ProducesResponseType(typeof(ResponseDto<OrdemServicoDto>), 400)]
        public async Task<IActionResult> DeletarItemOsAsync(int id)
        {
            var retorno = await _service.ApagarItemOsAsync(id);
            if (!retorno.Sucesso)
                return BadRequest(retorno);

            return Ok(retorno);
        }
    }
}
