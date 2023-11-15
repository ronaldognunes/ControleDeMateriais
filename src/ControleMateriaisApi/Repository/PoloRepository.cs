using ControleMateriaisApi.Domain;
using ControleMateriaisApi.Repository.Context;
using ControleMateriaisApi.Repository.Interfaces;

namespace ControleMateriaisApi.Repository
{
    public class PoloRepository : BaseRepository<Polo>,IPoloRepository
    {
        public PoloRepository(AplicationContext context) : base(context)
        {
        }
    }
}
