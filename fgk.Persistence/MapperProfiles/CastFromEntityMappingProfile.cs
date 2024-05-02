using AutoMapper;
using fgk.Core.Models;
using fgk.Persistence.Entities;

namespace fgk.Persistence.MapperProfiles;

public class CastFromEntityMappingProfile : Profile
{
    public CastFromEntityMappingProfile()
    {
        CreateMap<CastEntity, Cast>()
            .ForMember(ce => ce.FromMovie, opt => opt.Ignore());
    }
}
