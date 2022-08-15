using ControleMateriaisApi.Domain;
using ControleMateriaisApi.Repository.Context;
using ControleMateriaisApi.Repository.Interfaces;

namespace ControleMateriaisApi.Repository
{
    public class SaidaRepository : BaseRepository<Saida>, ISaidaRepository
    {
        public SaidaRepository(AplicationContext context) : base(context)
        {
        }
    }
}
