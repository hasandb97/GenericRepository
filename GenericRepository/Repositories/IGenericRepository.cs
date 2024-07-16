using GenericRepository.Model;
using System.Linq.Expressions;

namespace GenericRepository.Repositories
{
    public interface IGenericRepository <TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task AddEntity(TEntity entity);
        void DeleteEntity(TEntity entity);
        Task DeleteById(int id);
        void UpdateEntity(TEntity entity);

        Task<IEnumerable<TEntity>> GetItemsByExpression( Expression<Func<TEntity , bool>> expression);

    }
}
