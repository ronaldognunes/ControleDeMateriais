using ControleMateriaisApi.Domain;
using ControleMateriaisApi.Repository.Context;
using ControleMateriaisApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleMateriaisApi.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
    
        public UsuarioRepository(AplicationContext context) : base(context)
        {
        }

        public async Task<Usuario> EfetuarLoginAsync(string email , string senha)
        {
            var retorno = await _context
                .Usuarios
                .AsNoTrackingWithIdentityResolution()
                .FirstOrDefaultAsync(x => x.Email == email && x.Senha == senha);
            return retorno;
        }

        public async Task<Usuario> RecuperarEmailAsync(string email)
        {
            var retorno = await _context
                .Usuarios
                .AsNoTrackingWithIdentityResolution()
                .FirstOrDefaultAsync(x => x.Email == email);
            return retorno;
        }

        public async Task<IList<Usuario>> RecuperarUsuariosPorNomeAsync(string nome)
        {
            var retorno = await  _context
                .Usuarios
                .AsNoTrackingWithIdentityResolution()
                .Where(x => x.Nome == nome)
                .ToListAsync();
            return retorno;
        }

        public async Task<Usuario> RecuperarUsuariosPorCodigoAsync(int codigo, string email)
        {
            var retorno = await _context
                .Usuarios
                .AsNoTrackingWithIdentityResolution()
                .FirstOrDefaultAsync(x => x.CodigoRecuperarSenha == codigo && x.Email == email);
            return retorno;
        }

    }
}
