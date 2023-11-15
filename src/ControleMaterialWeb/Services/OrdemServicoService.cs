using ControleMateriaisApi.Dto;
using ControleMaterialWeb.Models;
using ControleMaterialWeb.Models.OrdemServico;
using ControleMaterialWeb.Services.Interfaces;
using System.ComponentModel;

namespace ControleMaterialWeb.Services
{
    public class OrdemServicoService : IOrdemServicoService
    {
        private readonly IHttpServices _httpServices ;
        private const string URI = "api/OrdemServico/";
        public OrdemServicoService(IHttpServices httpServices)
        {
            _httpServices = httpServices;
        }
        public async Task<ResponseDto<OrdemServicoDto>> AlterarOrdemServicoAsync(int id, EnviarAlteracaoDto OrdemServico)
        {
            try
            {
                return await _httpServices.HttpPutAsync<EnviarAlteracaoDto, ResponseDto<OrdemServicoDto>>($"{URI}alterar-os/{id}", OrdemServico);                
            }
            catch (Exception ex)
            {
                return new ResponseDto<OrdemServicoDto>() { Result = new OrdemServicoDto(), MensagensDeErros = new List<string>() { ex.Message}, Sucesso = false };
            }
        }

        public async Task<ResponseDto<OrdemServicoDto>> ApagarOrdemServicoAsync(int id)
        {
            try
            {
                return await _httpServices.HttpDeleteAsync<ResponseDto<OrdemServicoDto>>($"{URI}excluir-os/{id}");                
            }
            catch (Exception ex)
            {
                return new ResponseDto<OrdemServicoDto>() { Result = new OrdemServicoDto(), MensagensDeErros = new List<string>() { ex.Message }, Sucesso = false };
            }
        }

        public Task<IList<OrdemServicoDto>> ConsultarOrdemServicoAsync(string nome)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto<OrdemServicoDto>> InserirNovaOrdemServicoAsync(CadastroOrdemServicoDto OrdemServico)
        {
            try
            {
                return  await _httpServices.HttpPostAsync<CadastroOrdemServicoDto,ResponseDto<OrdemServicoDto>>($"{URI}cadastrar-os", OrdemServico);
                
            }
            catch (Exception ex)
            {
                return new ResponseDto<OrdemServicoDto>() { Result = new OrdemServicoDto(), MensagensDeErros = new List<string>() { ex.Message }, Sucesso = false };
            }
        
        }

        public async Task<ResponseDto<AlteracaoOrdemServicoDto>> RecuperarOrdemServicoAsync(int id)
        {
            try
            {
                return await _httpServices.HttpGetAsync<ResponseDto<AlteracaoOrdemServicoDto>>($"{URI}consultar-os-por-id/{id}");
                
            }
            catch (Exception ex)
            {
                return new ResponseDto<AlteracaoOrdemServicoDto>() { Result = new AlteracaoOrdemServicoDto(), MensagensDeErros = new List<string>() { ex.Message }, Sucesso = false };
            }
        }

        public async Task<ResponseDto<IList<OrdemServicoDto>>> RecuperarTodasOsAsync(string nome = "")
        {
            try
            {
                 return await _httpServices.HttpGetAsync<ResponseDto<IList<OrdemServicoDto>>>($"{URI}retornar-todas-os");               
            }
            catch (Exception ex)
            {
                return new ResponseDto<IList<OrdemServicoDto>> () { Result = new List<OrdemServicoDto>(), MensagensDeErros = new List<string>() { ex.Message }, Sucesso = false };
            }
        }

        public async Task<ResponseDto<ItemOrdenServicoDto>> InserirItensOs(IEnumerable<ItemOrdenServicoDto> itens)
        {
            try
            {
                return await _httpServices.HttpPostAsync<IEnumerable<ItemOrdenServicoDto>, ResponseDto<ItemOrdenServicoDto>>($"{URI}cadastrar-varios-itens-os", itens);
                
            }catch (Exception ex) 
            {
                return new ResponseDto<ItemOrdenServicoDto>() { Result = new ItemOrdenServicoDto(), MensagensDeErros = new List<string>(){ ex.Message}, Sucesso = false};
            }
        }

        public async Task<ResponseDto<IList<OrdemServicoDto>>> RecuperarTodasOsAsync(int? numeroOs = null, int qtdPaginas = 10, int pagina = 1)
        {
            try
            {
                if (numeroOs == null)
                    return await _httpServices.HttpGetAsync<ResponseDto<IList<OrdemServicoDto>>>($"{URI}retornar-todas-os/?qtdPorPagina={qtdPaginas}&pagina={pagina}");
                else
                    return await _httpServices.HttpGetAsync<ResponseDto<IList<OrdemServicoDto>>>($"{URI}retornar-todas-os/?qtdPorPagina={qtdPaginas}&pagina={pagina}&os={numeroOs}");

            }
            catch (Exception ex)
            {
                return new ResponseDto<IList<OrdemServicoDto>>() { Result = new List<OrdemServicoDto>(),MensagensDeErros = new List<string>() { ex.Message}, Sucesso = false };
            }
        }

        public async Task<ResponseDto<ItemOrdenServicoDto>> ExcluirItemOs(int idItem)
        {
            try
            {
                return await _httpServices.HttpDeleteAsync<ResponseDto<ItemOrdenServicoDto>>($"{URI}excluir-item-os/{idItem}");
            }
            catch (Exception ex)
            {
                return new ResponseDto<ItemOrdenServicoDto>() { Result = new ItemOrdenServicoDto(), MensagensDeErros = new List<string>() { ex.Message }, Sucesso = false };
            }
        }

        public async Task<ResponseDto<ArquivoDto>> GerarRelatorioAsync(TipoOrdemServico tipoOrdemServico, DateTime dataInicio, DateTime dataFim)
        {
            try
            {
                return await _httpServices.HttpGetAsync<ResponseDto<ArquivoDto>>($"{URI}relatorio-os/?tipoOrdem={tipoOrdemServico}&dataInicio={dataInicio.ToString("yyyy-MM-dd")}&dataFim={dataFim.ToString("yyyy-MM-dd")}");
            }
            catch (Exception ex)
            {
                return new ResponseDto<ArquivoDto>() { Result = new ArquivoDto(), MensagensDeErros = new List<string>() { ex.Message }, Sucesso = false };
            }
        }
    }
}
