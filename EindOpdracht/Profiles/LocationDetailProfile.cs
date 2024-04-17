using AutoMapper;
using EindOpdracht.DTO;
using EindOpdracht.Models;

namespace EindOpdracht.Profiles
{
    public class LocationDetailProfile : Profile
    {
        public LocationDetailProfile() 
        {
            CreateMap<Location, LocationDetailsDTO>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));

            CreateMap<Image, ImageDTO>()
            .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Url))
            .ForMember(dest => dest.IsCover, opt => opt.MapFrom(src => src.IsCover));

            CreateMap<Landlord, LandlordDTO>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
            .ForMember(dest => dest.Avatar, opt => opt.MapFrom(src => src.Avatar.Url));
        }

    }
}
