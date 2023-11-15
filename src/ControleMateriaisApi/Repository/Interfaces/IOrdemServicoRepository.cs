using ControleMateriaisApi.Domain;
using ControleMateriaisApi.Domain.Enum;

namespace ControleMateriaisApi.Repository.Interfaces
{
    public interface IOrdemServicoRepository : IBaseRepository<OrdemServico>
    {
        Task<IEnumerable<RelatorioOs>> GerarRelatorio(TipoOrdemServico? tipoOrdem, DateTime? dataInicio, DateTime? dataFim);
        Task<int?> CadastrarOsAsync(OrdemServico ordemServico);
        Task<OrdemServico?> RetornarOrdemServicoAsync(int id);
        Task<bool> VerificaMaterialAlgumaOs(int id);
        Task<bool> VerificaUsuarioPertenceAlgumaOs(int id);
        Task<bool> VerificaPoloAlgumaOs(int id);
    }
}
