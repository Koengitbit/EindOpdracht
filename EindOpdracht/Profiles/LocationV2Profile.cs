using AutoMapper;
using EindOpdracht.DTO;
using EindOpdracht.Models;

namespace EindOpdracht.Profiles
{
    public class LocationV2Profile : Profile
    {
        public LocationV2Profile()
        {
            CreateMap<Location, LocationDTOV2>()
                .ForMember(dest => dest.ImageURL, opt => opt.MapFrom(src => src.Images.FirstOrDefault(i => i.IsCover).Url))
                .ForMember(dest => dest.LandlordAvatarURL, opt => opt.MapFrom(src => src.Landlord.Avatar.Url))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.PricePerDay))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => (int)src.LocationType));
        }
    }
}
