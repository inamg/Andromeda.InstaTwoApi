using System.Collections.Generic;
using System.Threading.Tasks;
using Andromeda.InstaTwoApi.Api.Models.Dtos;
using Microsoft.AspNetCore.Http;

namespace Andromeda.InstaTwoApi.Api.Services
{
    public interface IImageService
    {
        Task<IList<ImageDto>> GetImages(int pageNo = 1, int pageSize = 10);
        Task<ImageDto> GetImage(int id);
        Task<int> SaveImage(IFormFile file, ImageDto image);
        int GetTotalCount();
    }
}