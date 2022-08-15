using ControleMateriaisApi.Domain;
using ControleMateriaisApi.Repository.Context;
using ControleMateriaisApi.Repository.Interfaces;

namespace ControleMateriaisApi.Repository
{
    public class SaidaMaterialRepository : BaseRepository<SaidaMaterial>,ISaidaMaterialRepository
    {
        public SaidaMaterialRepository(AplicationContext context) : base(context)
        {
        }
    }
}
