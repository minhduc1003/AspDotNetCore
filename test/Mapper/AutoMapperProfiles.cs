using AutoMapper;
using test.Models.Domain;
using test.Models.Dto;

namespace test.Mapper
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Regions, RegionsDto>().ReverseMap();
            CreateMap<RegionActionDto, Regions > ().ReverseMap();
            CreateMap<Walks, WalkDto>().ReverseMap();
            CreateMap<WalkActionDto, Walks> ().ReverseMap();
            CreateMap<WalkDto, Walks>().ReverseMap();
            CreateMap<Difficulty, DifficultyDto>().ReverseMap();

        }
    }
}
