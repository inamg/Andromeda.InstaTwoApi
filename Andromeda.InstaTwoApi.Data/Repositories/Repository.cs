using System;
using System.Linq;
using System.Threading.Tasks;

namespace Andromeda.InstaTwoApi.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private readonly InstaContext _instaContext;

        protected Repository(InstaContext instaContext)
        {
            _instaContext = instaContext;
        }

        public TEntity GetById(int id)
        {
            try
            {
                return _instaContext.Find<TEntity>(id);
            }
            catch (Exception)
            {
                throw new Exception("Couldn't retrieve entities");
            }
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return _instaContext.Set<TEntity>();
            }
            catch (Exception)
            {
                throw new Exception("Couldn't retrieve entities");
            }
        }

        public TEntity Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(Add)} entity must not be null");
            }

            try
            {
                 _instaContext.Add(entity);
                 _instaContext.SaveChanges();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entity)} could not be saved");
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(UpdateAsync)} entity must not be null");
            }

            try
            {
                _instaContext.Update(entity);
                await _instaContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entity)} could not be updated");
            }
        }

        public int Count()
        {
            return _instaContext.Set<TEntity>().Count();
        }
    }
}