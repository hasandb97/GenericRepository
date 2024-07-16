using GenericRepository.Data;
using GenericRepository.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace GenericRepository.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly MyDBContextClass _context;
        private readonly DbSet<TEntity> _entities;
        public GenericRepository(MyDBContextClass context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }
        public async Task AddEntity(TEntity entity)
        {
            await _entities.AddAsync(entity);
        }

        public async Task DeleteById(int id)
        {
            var item = await _entities.FindAsync(id);
            _entities.Remove(item);
        }

        public void DeleteEntity(TEntity entity)
        {
             _entities.Remove(entity);    
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetItemsByExpression(Expression<Func<TEntity, bool>> expression)
        {
            return await _entities.Where(expression).ToListAsync();
        }

        public  void UpdateEntity(TEntity entity)
        {
             _entities.Update(entity);
        }
    }
}
