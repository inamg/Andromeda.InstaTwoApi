using System.Threading.Tasks;
using Andromeda.InstaTwoApi.Data.Repositories;

namespace Andromeda.InstaTwoApi.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InstaContext _context;
            
        public IUserRepository UserRepository { get; }
        public IImageRepository ImageRepository { get; }

        public UnitOfWork(InstaContext context)
        {
            _context = context;
            
            UserRepository = new UserRepository(_context);
            ImageRepository = new ImageRepository(_context);
        }
        
        public async Task<int> SaveAsync()
        {
           return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}