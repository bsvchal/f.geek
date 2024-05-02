using AutoMapper;
using fgk.Core.Models;
using fgk.Persistence.Entities;

namespace fgk.Persistence.MapperProfiles;

public class CrewFromEntityMappingProfile : Profile
{
    public CrewFromEntityMappingProfile()
    {
        CreateMap<CrewEntity, Crew>()
            .ForMember(ce => ce.FromMovie, opt => opt.Ignore());
    }
}
