using ControleMateriaisApi.Domain.Enum;
using ControleMateriaisApi.Dto;

namespace ControleMateriaisApi.Services.Interfaces
{
    public interface IOrdemServicoService
    {
        Task<ResponseDto<RetornoOrdemServicoDto>> ConsultarOsPorIdAsync(int id);
        Task<ResponseDto<OrdemServicoDto>> CadastrarOsAsync(CadastroOrdemServicoDto os);
        Task<ResponseDto<OrdemServicoDto>> DeletarOsAsync(int id);
        Task<ResponseDto<OrdemServicoDto>> AlterarOsAsync(int id, AlteracaoOrdemServicoDto os);
        Task<ResponseDto<IList<OrdemServicoDto>>> ListarTodasOsAsync(int qtdPorPag = 10, int pag = 1);
        Task<ResponseDto<IList<OrdemServicoDto>>> ListarTodasOsAsync( int idOs, int qtdPorPag = 10, int pag = 1);
        Task<ResponseDto<IList<ItemOrdemServicoDto>>> ListarTodosItensOsAsync(int idOs, int qtdPorPag = 10, int pag = 1);
        Task<ResponseDto<ItemOrdemServicoDto>> CadastrarItemOsAsync(CadastroItemOrdemServicoDto item);
        Task<ResponseDto<ItemOrdemServicoDto>> AlterarItemOsAsync(ItemOrdemServicoDto item);
        Task<ResponseDto<ItemOrdemServicoDto>> ApagarItemOsAsync(int id);
        Task<ResponseDto<ArquivoDto>> GerarRelatorioAsync(TipoOrdemServico? tipoOrdem, DateTime? dataInicio, DateTime? dataFim);
        Task<ResponseDto<ItemOrdemServicoDto>> CadastrarVariosItensOsAsync(IList<CadastroItemOrdemServicoDto> oss);
        Task<ResponseDto<OrdemServicoDto>> CadastrarOsReturnaId(CadastroOrdemServicoDto os);
        Task<ResponseDto<IList<ItemOrdemServicoDto>>> ListarTodasItensOsAsync(int idOs, int qtdPorPag = 10, int pag = 1);

    }
}
