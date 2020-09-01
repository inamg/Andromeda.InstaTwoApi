using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Andromeda.InstaTwoApi.Api.Models.Dtos;
using Andromeda.InstaTwoApi.Data;
using Andromeda.InstaTwoApi.Data.Models;
using AutoMapper;
using Guards;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Andromeda.InstaTwoApi.Api.Services
{
    public class ImagesService : IImageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ImagesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<ImageDto>> GetImages(int pageNo = 1, int pageSize = 10)
        {
            Guard.ArgumentIsGreaterThan(() => pageSize, 0);
            Guard.ArgumentIsGreaterThan(() => pageNo, 0);

            var images = await _unitOfWork.ImageRepository
                .GetAll()
                .Skip(pageSize * pageNo)
                .Take(pageSize)
                .ToListAsync();

            return _mapper.Map<IList<ImageDto>>(images);
        }
        
        public async Task<ImageDto> GetImage(int id)
        {
            Guard.ArgumentIsGreaterThan(() => id, 0);

            var image = await _unitOfWork.ImageRepository.GetById(id);
            return image != null ? _mapper.Map<ImageDto>(image) : null;
        }
        
        public int GetTotalCount()
        {
            return _unitOfWork.ImageRepository.Count();
        }

        public async Task<int> SaveImage(IFormFile file, ImageDto image)
        {
            var imageEntity = _mapper.Map<Image>(image);
            
           await _unitOfWork.ImageRepository.AddAsync(imageEntity);

            return await _unitOfWork.SaveAsync();
        }
    }
}