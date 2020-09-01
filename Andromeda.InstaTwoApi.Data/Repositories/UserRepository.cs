using Andromeda.InstaTwoApi.Data.Models;

namespace Andromeda.InstaTwoApi.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly InstaContext _instaContext;

        public UserRepository(InstaContext instaContext) : base(instaContext)
        {
            _instaContext = instaContext;
        }
    }
}