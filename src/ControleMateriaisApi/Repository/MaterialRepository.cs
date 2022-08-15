using ControleMateriaisApi.Domain;
using ControleMateriaisApi.Repository.Context;
using ControleMateriaisApi.Repository.Interfaces;

namespace ControleMateriaisApi.Repository
{
    public class MaterialRepository : BaseRepository<Material>,IMaterialRepository
    {
        public MaterialRepository(AplicationContext context) : base(context)
        {
        }
    }
}
