using ApplicationCore.Models.Dtos;
using ApplicationCore.Models.Entities;
using ApplicationCore.Models.Enums;
using AutoMapper;

namespace ApplicationCore.Profiles
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Motorcycle, MotorcycleDto>().
                ForMember(dest => dest.ModelType, opt => opt.MapFrom(src => src.ModelType.ToString()));
            CreateMap<MotorcycleDto, Motorcycle>().
                ForMember(dest => dest.ModelType, opt => opt.MapFrom(src => Enum.Parse<ModelType>(src.ModelType)));
        }
    }
}
