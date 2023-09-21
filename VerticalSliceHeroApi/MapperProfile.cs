using AutoMapper;
using VerticalSliceHeroApi.Domain;
using VerticalSliceHeroApi.Features.Heroes.Command;
using VerticalSliceHeroApi.Features.Heroes.Query;

namespace VerticalSliceHeroApi
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Hero, GetHeroResponse>();
            CreateMap<AddHeroCommand, Hero>();
            CreateMap<UpdateHeroCommand, Hero>();
        }
    }
}
