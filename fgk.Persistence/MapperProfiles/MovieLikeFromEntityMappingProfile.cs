using AutoMapper;
using fgk.Core.Models;
using fgk.Persistence.Entities;

namespace fgk.Persistence.MapperProfiles;

public class MovieLikeFromEntityMappingProfile : Profile
{
    public MovieLikeFromEntityMappingProfile()
    {
        CreateMap<MovieLikeEntity, MovieLike>()
            .ForMember(mle => mle.LikedBy, opt => opt.Ignore());
    }
}
