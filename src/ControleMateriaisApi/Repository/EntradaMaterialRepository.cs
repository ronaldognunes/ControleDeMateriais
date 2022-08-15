using ControleMateriaisApi.Domain;
using ControleMateriaisApi.Repository.Context;
using ControleMateriaisApi.Repository.Interfaces;

namespace ControleMateriaisApi.Repository
{
    public class EntradaMaterialRepository : BaseRepository<EntradaMaterial>,IEntradaMaterialRepository
    {
        public EntradaMaterialRepository(AplicationContext context) : base(context)
        {
        }
    }
}
