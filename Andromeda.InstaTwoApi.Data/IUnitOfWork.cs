using System;
using System.Threading.Tasks;
using Andromeda.InstaTwoApi.Data.Repositories;

namespace Andromeda.InstaTwoApi.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IImageRepository ImageRepository { get; }

        Task<int> SaveAsync();
    }
}