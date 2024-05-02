using AutoMapper;
using fgk.Core.Contracts;
using fgk.Persistence.Entities;

namespace fgk.Persistence.MapperProfiles
{
    public class MovieDetailsFromEntityMappingProfile : Profile
    {
        public MovieDetailsFromEntityMappingProfile()
        {
            CreateMap<MovieEntity, MovieDisplay>();
        }
    }
}
