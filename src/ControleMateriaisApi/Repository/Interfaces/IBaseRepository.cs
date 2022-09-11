using ControleMateriaisApi.Domain;

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

    }
}
