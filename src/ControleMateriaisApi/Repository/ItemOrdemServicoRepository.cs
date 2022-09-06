using ControleMateriaisApi.Domain;
using ControleMateriaisApi.Repository.Context;
using ControleMateriaisApi.Repository.Interfaces;

namespace ControleMateriaisApi.Repository
{
    public class ItemOrdemServicoRepository : BaseRepository<ItemOrdemServico>,IItemOrdemServicoRepository
    {
        public ItemOrdemServicoRepository(AplicationContext context) : base(context)
        {
        }
    }
}
