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

        public async Task<TEntity> GetById(int id)
        {
            try
            {
                return await _instaContext.FindAsync<TEntity>(id);
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

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await _instaContext.AddAsync(entity);
                await _instaContext.SaveChangesAsync();

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
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
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