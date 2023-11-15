using ControleMateriaisApi.Domain;

namespace ControleMateriaisApi.Repository.Interfaces
{
    public interface IItemOrdemServicoRepository : IBaseRepository<ItemOrdemServico>
    {
        Task<(IList<ItemOrdemServico> itens, decimal totalDePaginas, int totalDeItens)> RetornarItensOrdemServicoComMateriais(int id, int qtdPorPagina = 10, int pagina = 1);
        Task<bool> DeletarTodosItens(int idOs);
    }
}
