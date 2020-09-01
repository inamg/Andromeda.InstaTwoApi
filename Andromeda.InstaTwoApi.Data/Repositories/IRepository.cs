using System.Linq;
using System.Threading.Tasks;

namespace Andromeda.InstaTwoApi.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        Task<TEntity> GetById(int id);
        
        IQueryable<TEntity> GetAll();

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        int Count();
    }
}