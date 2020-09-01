using Andromeda.InstaTwoApi.Api.Models.Dtos;
using Andromeda.InstaTwoApi.Data.Models;
using AutoMapper;

namespace Andromeda.InstaTwoApi.Api.Infrastructure.Profiles
{
    public class EntityDtoMappings : Profile
    {
        public EntityDtoMappings()
        {
            CreateMap<Image, ImageDto>();
            CreateMap<ImageDto, Image>();
        }
    }
}