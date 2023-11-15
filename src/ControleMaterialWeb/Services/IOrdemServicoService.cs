using ControleMaterialWeb.Models.Material;
using ControleMaterialWeb.Models;
using ControleMaterialWeb.Models.OrdemServico;
using ControleMateriaisApi.Dto;

namespace ControleMaterialWeb.Services
{
    public interface IOrdemServicoService
    {
        Task<ResponseDto<AlteracaoOrdemServicoDto>> RecuperarOrdemServicoAsync(int id);
        Task<ResponseDto<IList<OrdemServicoDto>>> RecuperarTodasOsAsync(int? numeroOs = null, int qtdPaginas = 10, int pagina = 1);
        Task<ResponseDto<OrdemServicoDto>> ApagarOrdemServicoAsync(int id);
        Task<ResponseDto<OrdemServicoDto>> AlterarOrdemServicoAsync(int id, EnviarAlteracaoDto OrdemServico);
        Task<ResponseDto<OrdemServicoDto>> InserirNovaOrdemServicoAsync(CadastroOrdemServicoDto OrdemServico);
        Task<ResponseDto<ItemOrdenServicoDto>> InserirItensOs(IEnumerable<ItemOrdenServicoDto> itens);
        Task<ResponseDto<ItemOrdenServicoDto>> ExcluirItemOs(int idItem);
        Task<ResponseDto<ArquivoDto>> GerarRelatorioAsync(TipoOrdemServico tipoOrdemServico,DateTime dataInicio, DateTime dataFim);
    }
}
