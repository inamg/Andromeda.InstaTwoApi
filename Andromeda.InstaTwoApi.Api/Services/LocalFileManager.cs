using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Andromeda.InstaTwoApi.Api.Services
{
    public class LocalFileManager : IImageFileManager
    {
        private readonly string ImageDirectory = "/images";

        public async Task SaveImage(IFormFile file)
        {
            await using var stream = System.IO.File.Create($"{ImageDirectory}/{file.Name}");
            await file.CopyToAsync(stream);
        }
    }
}