using ControleMateriaisApi.Domain;

namespace ControleMateriaisApi.Repository.Interfaces
{
    public interface IUsuarioRepository:IBaseRepository<Usuario>
    {
        public Task<IList<Usuario>> RecuperarUsuariosPorNomeAsync(string nome);

        public Task<Usuario> EfetuarLoginAsync(string email, string senha);
    }
}
