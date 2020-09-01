using Andromeda.InstaTwoApi.Api.Services;
using Andromeda.InstaTwoApi.Data;
using AutoMapper;
using Xunit;

namespace Andromeda.InstaTwoApi.Tests.Services
{
    public class ImagesServiceTests
    {
        private readonly ImagesService _imagesService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ImagesServiceTests(ImagesService imagesService)
        {
           // _imagesService = new ImagesService();
        }

        [Fact]
        public void GetImages_WhenIsInvalid_ShouldThrowException()
        {
            
        }
    }
}