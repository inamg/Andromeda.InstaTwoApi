using System.Linq;
using System.Threading.Tasks;

namespace Andromeda.InstaTwoApi.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        TEntity GetById(int id);
        
        IQueryable<TEntity> GetAll();

        TEntity Add(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        int Count();
    }
}