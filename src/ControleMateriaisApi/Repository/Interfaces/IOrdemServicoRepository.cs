using ControleMateriaisApi.Domain;
using ControleMateriaisApi.Domain.Enum;

namespace ControleMateriaisApi.Repository.Interfaces
{
    public interface IOrdemServicoRepository : IBaseRepository<OrdemServico>
    {
        Task<IEnumerable<RelatorioOs>> GerarRelatorio(TipoOrdemServico? tipoOrdem, DateTime? dataInicio, DateTime? dataFim);
    }
}
