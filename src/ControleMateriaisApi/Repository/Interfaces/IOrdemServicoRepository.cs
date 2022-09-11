using ControleMateriaisApi.Domain;

namespace ControleMateriaisApi.Repository.Interfaces
{
    public interface IOrdemServicoRepository : IBaseRepository<OrdemServico>
    {
        Task<dynamic> GerarRelatorio();
    }
}
