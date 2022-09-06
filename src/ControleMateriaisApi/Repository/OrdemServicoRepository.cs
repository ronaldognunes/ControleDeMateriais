using ControleMateriaisApi.Domain;
using ControleMateriaisApi.Repository.Context;
using ControleMateriaisApi.Repository.Interfaces;

namespace ControleMateriaisApi.Repository
{
    public class OrdemServicoRepository : BaseRepository<OrdemServico>,IOrdemServicoRepository
    {
        public OrdemServicoRepository(AplicationContext context) : base(context)
        {
        }
    }
}
