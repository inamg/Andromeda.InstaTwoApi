using System.Collections.Generic;
using System.Threading.Tasks;
using Andromeda.InstaTwoApi.Api.Models.Dtos;
using Microsoft.AspNetCore.Http;

namespace Andromeda.InstaTwoApi.Api.Services
{
    public interface IImageService
    {
        IList<ImageDto> GetImages(int pageNo = 1, int pageSize = 10);
        ImageDto GetImage(int id);
        int SaveImage(IFormFile file, ImageDto image);
        int GetTotalCount();
    }
}