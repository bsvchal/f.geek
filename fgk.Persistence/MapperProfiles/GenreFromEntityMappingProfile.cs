using AutoMapper;
using fgk.Core.Models;
using fgk.Persistence.Entities;

namespace fgk.Persistence.MapperProfiles;

public class GenreFromEntityMappingProfile : Profile
{
    public GenreFromEntityMappingProfile()
    {
        CreateMap<GenreEntity, Genre>()
            .ForMember(gn => gn.MoviesOfThisGenre, opt => opt.Ignore());
    }
}
