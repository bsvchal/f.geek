using AutoMapper;
using fgk.Core.Models;
using fgk.Persistence.Entities;

namespace fgk.Persistence.MapperProfiles;

public class KeywordFromEntityMappingProfile : Profile
{
    public KeywordFromEntityMappingProfile()
    {
        CreateMap<KeywordEntity, Keyword>()
            .ForMember(ke => ke.MoviesWithThisKeyword, opt => opt.Ignore());
    }
}
