

using Flexbook.Data.DataAccess;

namespace Flexbook.Services
{
    public class CrudService<T> : ICrudService<T> where T : class
    {
        protected readonly FlexbookDbContext _dbContext;

        public CrudService(FlexbookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public virtual void Insert(T entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
