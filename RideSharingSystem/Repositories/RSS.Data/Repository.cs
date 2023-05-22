using Microsoft.EntityFrameworkCore;
using RSS.Data.Interfaces;
using System.Linq.Expressions;
namespace RSS.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly RideSharingDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;
        public Repository(RideSharingDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public IList<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }
        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }
        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
    }
}
