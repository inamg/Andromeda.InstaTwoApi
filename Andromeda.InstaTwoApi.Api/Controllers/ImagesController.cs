using System.Collections.Generic;
using Andromeda.InstaTwoApi.Api.Models;
using Andromeda.InstaTwoApi.Api.Models.Dtos;
using Andromeda.InstaTwoApi.Api.Models.ViewModels;
using Andromeda.InstaTwoApi.Api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Andromeda.InstaTwoApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;

        public ImagesController(IImageService imageService, IMapper mapper)
        {
            _imageService = imageService;
            _mapper = mapper;
        }

        // GET
        public IActionResult Index(int pageNo = 1, int pageSize = 10)
        {
            var images = _imageService.GetImages(pageNo, pageSize);
            var imagesVm = _mapper.Map<IList<ImageViewModel>>(images);
            var count = _imageService.GetTotalCount();

            return Ok(new PaginatedModel<ImageViewModel>(pageNo, pageSize, count, imagesVm));
        }

        [Route("id")]
        public IActionResult Get(int id)
        {
            var image = _imageService.GetImage(id);
            var imageVm = _mapper.Map<ImageViewModel>(image);
     
            return Ok(imageVm);
        }

        public IActionResult Post(IFormFile file, ImageViewModel image)
        {
            // check the validation of the image

            var imageDto = _mapper.Map<ImageDto>(image);
            
           return Ok(_imageService.SaveImage(file,imageDto));
        }
    }
}