using Andromeda.InstaTwoApi.Api.Models.Dtos;
using Andromeda.InstaTwoApi.Api.Models.ViewModels;
using AutoMapper;

namespace Andromeda.InstaTwoApi.Api.Infrastructure.Profiles
{
    public class ViewModelDtoMappings : Profile
    {
        public ViewModelDtoMappings()
        {
            CreateMap<ImageViewModel, ImageDto>();
            CreateMap<ImageDto, ImageViewModel>();
        }
    }
}