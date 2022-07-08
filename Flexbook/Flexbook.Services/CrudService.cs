

using Flexbook.Data.DataAccess;
using System.Diagnostics.CodeAnalysis;

namespace Flexbook.Services
{
    public class CrudService<T> : ICrudService<T> where T : class
    {
        protected readonly FlexbookDbContext _dbContext;

        public CrudService(FlexbookDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public CrudService()
        {
            _dbContext = new FlexbookDbContext();
        }

        [return: MaybeNull]
        public virtual T? GetById(int id)
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
            if (entity != null)
            {
                _dbContext.Remove(entity);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException($"Can't delete an entity that doesn't exist!");
            }
        }

        public virtual void Update(T entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
