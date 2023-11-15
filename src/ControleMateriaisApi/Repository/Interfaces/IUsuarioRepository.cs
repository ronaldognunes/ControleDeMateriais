using ControleMateriaisApi.Domain;

namespace ControleMateriaisApi.Repository.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<IList<Usuario>> RecuperarUsuariosPorNomeAsync(string nome);
        Task<Usuario> EfetuarLoginAsync(string email, string senha);
        Task<Usuario> RecuperarEmailAsync(string email);
        Task<Usuario> RecuperarUsuariosPorCodigoAsync(int codigo, string email);
    }
}
