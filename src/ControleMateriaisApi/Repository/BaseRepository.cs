using ControleMateriaisApi.Domain;
using ControleMateriaisApi.Repository.Context;
using ControleMateriaisApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ControleMateriaisApi.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : Entity
    {
        protected readonly DbSet<T> _db;
        protected readonly AplicationContext _context;
        public BaseRepository(AplicationContext context)
        {
            _db = context.Set<T>();
            _context = context;
        }

        public async Task<bool> AlterarAsync(T entity)
        {
            _db.Update(entity);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> CadastrarAsync(T entity)
        {
            await _db.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CadastrarVariosAsync(List<T> entity)
        {
            await _db.AddRangeAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<(List<T> items, decimal total, int registros)> ConsultaPaginadaAsync(Expression<Func<T, bool>>? funcao, int qtdPorPagina = 10, int pagina = 1)
        {
            decimal totalDeItens; 
            decimal totalDePaginas; 
            List<T> itens = new List<T>();

            if (funcao is null)
            {
                totalDeItens =  await _db.AsQueryable<T>().CountAsync() ;
                totalDePaginas =  Math.Ceiling(totalDeItens / qtdPorPagina);
                itens = await _db
                    .AsNoTrackingWithIdentityResolution()
                    .Skip((pagina - 1) * qtdPorPagina)
                    .Take(qtdPorPagina)
                    .ToListAsync();
                return (itens, totalDePaginas, Convert.ToInt32(totalDeItens));
            }

            totalDeItens =  await _db.AsQueryable<T>().Where(funcao).CountAsync()  ;
            totalDePaginas =  Math.Ceiling(totalDeItens / qtdPorPagina);
            itens = await _db
                .AsNoTrackingWithIdentityResolution()
                .Where(funcao)
                .Skip((pagina - 1) * qtdPorPagina)
                .Take(qtdPorPagina)                
                .ToListAsync();

            return (itens, totalDePaginas, Convert.ToInt32(totalDeItens));

        }

        public async Task<bool> DeletarAsync(T entity)
        {
            _db.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<T> RecuperarDadosPorFiltroAsync(Expression<Func<T, bool>> funcao)
        {
            var result =await _db
                .AsNoTrackingWithIdentityResolution()
                .FirstOrDefaultAsync(funcao);
            return result;
        }

        public async Task<T> RecuperarPorIdAsync(int id)
        {

            var result = await _db
                .AsNoTrackingWithIdentityResolution()
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<List<T>> RecuperarTodosAsync()
        {
            var result = await _db
                .AsNoTrackingWithIdentityResolution()
                .ToListAsync();
            return result;
        }
    }
}
