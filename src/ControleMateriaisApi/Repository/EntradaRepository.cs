using ControleMateriaisApi.Domain;
using ControleMateriaisApi.Repository.Context;
using ControleMateriaisApi.Repository.Interfaces;

namespace ControleMateriaisApi.Repository
{
    public class EntradaRepository : BaseRepository<Entrada>,IEntradaRepository
    {
        public EntradaRepository(AplicationContext context) : base(context)
        {
        }
    }
}
