using ControleMateriaisApi.Domain;
using ControleMateriaisApi.Repository.Context;
using ControleMateriaisApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleMateriaisApi.Repository
{
    public class MaterialRepository : BaseRepository<Material>,IMaterialRepository
    {
        public MaterialRepository(AplicationContext context) : base(context)
        {
        }

        public async Task<IList<Material>> RecuperarMaterialPorNomeAsync(string nome)
        {
            var retorno = await _db
                .AsNoTrackingWithIdentityResolution()
                .Where(x => x.Nome == nome)
                .ToListAsync();
            return retorno;

        }
    }
}
