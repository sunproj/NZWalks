using AutoMapper;

namespace NZWalks.API.Profiles
{
    public class WalkProfile:Profile
    {
        public WalkProfile()
        {
            CreateMap<Models.Domain.Walk, Models.DTO.Walkdto>()
                .ReverseMap();

            CreateMap<Models.Domain.WalkDifficulty, Models.DTO.WalkDifficultydto>()
                .ReverseMap();
        }
    }
}
