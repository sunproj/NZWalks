using AutoMapper;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Profiles
{
    public class RegionProfile:Profile
    {
        public RegionProfile()
        {
            CreateMap<Region, Regiondto>()
                .ForMember(
                    dest => dest.Id,
                    options => options.MapFrom(src => src.Id))
            .ForMember(
                    dest => dest.RName,
                    options => options.MapFrom(src => src.Name))
             .ForMember(
                    dest => dest.RArea,
                    options => options.MapFrom(src => src.Area))
             .ForMember(
                    dest => dest.RCode,
                    options => options.MapFrom(src => src.Code))
             .ForMember(
                    dest => dest.RLat,
                    options => options.MapFrom(src => src.Lat))
             .ForMember(
                    dest => dest.RLong,
                    options => options.MapFrom(src => src.Long))
              .ForMember(
                    dest => dest.RPopulation,
                    options => options.MapFrom(src => src.Population));
        }
    }
}
