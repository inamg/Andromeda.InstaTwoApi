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
        
        public int Save()
        {
           return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}