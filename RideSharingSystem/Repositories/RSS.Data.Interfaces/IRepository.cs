using System.Linq.Expressions;

namespace RSS.Data.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IList<TEntity> GetAll();
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}