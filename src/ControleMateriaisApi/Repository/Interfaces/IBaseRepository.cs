using ControleMateriaisApi.Domain;
using System.Linq.Expressions;

namespace ControleMateriaisApi.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : Entity
    {
        Task<T> RecuperarPorIdAsync(int id);
        Task<List<T>> RecuperarTodosAsync();
        Task<bool> CadastrarAsync(T entity);
        Task<bool> CadastrarVariosAsync(List<T> entity);
        Task<bool> DeletarAsync(T entity);
        Task<bool> AlterarAsync(T entity);
        Task<T> RecuperarDadosPorFiltroAsync(Expression<Func<T, bool>> funcao);
        Task<(List<T> items, decimal total, int registros)> ConsultaPaginadaAsync(Expression<Func<T,bool>>? funcao, int totalItemsPorPagina = 10 , int pagina = 1 );

    }
}
