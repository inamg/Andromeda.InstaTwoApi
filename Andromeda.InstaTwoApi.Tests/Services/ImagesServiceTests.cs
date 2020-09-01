using System;
using System.Linq;
using System.Threading.Tasks;
using Andromeda.InstaTwoApi.Api.Infrastructure.Profiles;
using Andromeda.InstaTwoApi.Api.Services;
using Andromeda.InstaTwoApi.Data;
using Andromeda.InstaTwoApi.Data.Models;
using Andromeda.InstaTwoApi.Data.Repositories;
using AutoFixture;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Andromeda.InstaTwoApi.Tests.Services
{
    public class ImagesServiceTests
    {
        private readonly ImagesService _imagesService;
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly Fixture _fixture;

        public ImagesServiceTests()
        {
            _fixture = new Fixture();
            _unitOfWork = Substitute.For<IUnitOfWork>();
            
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new EntityDtoMappings());
                cfg.AddProfile(new ViewModelDtoMappings());
            });
            _mapper = new Mapper(mapperConfiguration);
            
             _imagesService = new ImagesService(_unitOfWork, _mapper);
        }

        [Fact]
        public void GetImages_WhenPageNoIsInvalid_ShouldThrowException()
        {
            // Act & Assert
             Assert.Throws<ArgumentOutOfRangeException>(()=> _imagesService.GetImages(-1, 1));
        }
        
        [Fact]
        public void GetImages_WhenPageSizeIsInvalid_ShouldThrowException()
        {
            // Act & Assert
             Assert.Throws<ArgumentOutOfRangeException>(()=> _imagesService.GetImages(1, -1));
        }
        
        [Fact]
        public void GetImages_WhenInputIsValid_ShouldReturnDtos()
        {
            // Arrange
            var images = _fixture.CreateMany<Image>(10).AsQueryable();
            var mockImageRepo = Substitute.For<IImageRepository>();
            mockImageRepo.GetAll().Returns((IQueryable)images);

            _unitOfWork.ImageRepository.Returns(mockImageRepo);
            
            // Act
            var imagesDto = _imagesService.GetImages();
            
            //Assert
            imagesDto.Should().BeEquivalentTo(images);
        }
        
        [Fact]
        public void GetImage_WhenIdIsProvided_ShouldReturnDtos()
        {
            // Arrange
            var image = _fixture.Create<Image>();
            var mockImageRepo = Substitute.For<IImageRepository>();
            mockImageRepo.GetById(10).Returns(image);

            _unitOfWork.ImageRepository.Returns(mockImageRepo);
            
            // Act
            var imageDto = _imagesService.GetImage(10);
            
            //Assert
            imageDto.Should().BeEquivalentTo(image);
        }
    }
}