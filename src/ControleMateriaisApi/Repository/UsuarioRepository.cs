using ControleMateriaisApi.Domain;
using ControleMateriaisApi.Repository.Context;
using ControleMateriaisApi.Repository.Interfaces;

namespace ControleMateriaisApi.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AplicationContext context) : base(context)
        {
        }
    }
}
