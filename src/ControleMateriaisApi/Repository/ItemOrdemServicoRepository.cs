using ControleMateriaisApi.Domain;
using ControleMateriaisApi.Repository.Context;
using ControleMateriaisApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleMateriaisApi.Repository
{
    public class ItemOrdemServicoRepository : BaseRepository<ItemOrdemServico>,IItemOrdemServicoRepository
    {
        public ItemOrdemServicoRepository(AplicationContext context) : base(context)
        {
        }

        public async Task<bool> DeletarTodosItens(int idOs)
        {
            var items = await _db
                .AsNoTrackingWithIdentityResolution()
                .Where(x => x.IdOs == idOs)
                .ToListAsync();

            foreach (var item in items)
            {
                await DeletarAsync(item);
            }

            return true;
        }

        public async Task<(IList<ItemOrdemServico> itens, decimal totalDePaginas, int totalDeItens)> RetornarItensOrdemServicoComMateriais(int id, int qtdPorPagina = 10, int pagina = 1)
        {
            decimal totalDeItens; 
            decimal totalDePaginas; 
            List<ItemOrdemServico> itens = new List<ItemOrdemServico>();            

            totalDeItens =  await _db.AsQueryable<ItemOrdemServico>().CountAsync()  ;
            totalDePaginas =  Math.Ceiling(totalDeItens / qtdPorPagina);
            itens = await _db
                .AsNoTrackingWithIdentityResolution()
                .Skip((pagina - 1) * qtdPorPagina)
                .Where( p => p.IdOs == id)
                .Take(qtdPorPagina) 
                .Include( p => p.Material)               
                .ToListAsync();

            return (itens, totalDePaginas, Convert.ToInt32(totalDeItens));
        }
    }
}
