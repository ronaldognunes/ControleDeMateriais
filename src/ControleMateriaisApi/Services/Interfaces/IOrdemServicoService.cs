using ControleMateriaisApi.Domain.Enum;
using ControleMateriaisApi.Dto;

namespace ControleMateriaisApi.Services.Interfaces
{
    public interface IOrdemServicoService
    {
        Task<ResponseDto<OrdemServicoDto>> ConsultarOsPorIdAsync(int id);
        Task<ResponseDto<OrdemServicoDto>> CadastrarOsAsync(CadastroOrdemServicoDto os);
        Task<ResponseDto<OrdemServicoDto>> DeletarOsAsync(int id);
        Task<ResponseDto<OrdemServicoDto>> AlterarOsAsync(int id, OrdemServicoDto os);
        Task<ResponseDto<IList<OrdemServicoDto>>> ListarTodasOsAsync();
        Task<ResponseDto<IList<OrdemServicoDto>>> ConsultarOsPorNomesAsync(string nome);
        Task<ResponseDto<IList<ItemOrdemServicoDto>>> ListarTodosItensOsAsync(int idOs);
        Task<ResponseDto<ItemOrdemServicoDto>> CadastrarItemOsAsync(CadastroItemOrdemServicoDto item);
        Task<ResponseDto<ItemOrdemServicoDto>> AlterarItemOsAsync(ItemOrdemServicoDto item);
        Task<ResponseDto<ItemOrdemServicoDto>> ApagarItemOsAsync(int id);
        Task<ResponseDto<ArquivoDto>> GerarRelatorioAsync(TipoOrdemServico? tipoOrdem, DateTime? dataInicio, DateTime? dataFim);

    }
}
