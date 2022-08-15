using ControleMateriaisApi.Domain;
using ControleMateriaisApi.Repository.Context;
using ControleMateriaisApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleMateriaisApi.Repository
{
    public abstract class BaseRepository<T>:IBaseRepository<T> where T : Entity
    {
        private readonly DbSet<T> _db;
        private readonly AplicationContext _context;    
        public BaseRepository(AplicationContext context)
        {   
            _db = context.Set<T>();
            _context = context; 
        }

        public async Task<bool> AlterarAsync(int id, T entity)
        {
            var result = await _db.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
                return false;

            _db.Update(entity);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> CadastrarAsync(T entity)
        {
            await  _db.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletarAsync(T entity)
        {
            _db.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<T> RecuperarPorIdAsync(int id)
        {
            var result = await _db.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<List<T>> RecuperarTodosAsync()
        {
            var result = await _db.ToListAsync();
            return result;
        }
    }
}
