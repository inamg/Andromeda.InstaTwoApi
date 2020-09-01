using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Andromeda.InstaTwoApi.Api.Services
{
    public interface IImageFileManager
    {
        Task SaveImage(IFormFile file);
    }
}