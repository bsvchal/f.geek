using AutoMapper;
using fgk.Core.Models;
using fgk.Persistence.Entities;

namespace fgk.Persistence.MapperProfiles;

public class VideoFromEntityMappingProfile : Profile
{
    public VideoFromEntityMappingProfile()
    {
        CreateMap<VideoEntity, Video>()
            .ForMember(ve => ve.FromMovie, opt => opt.Ignore());
    }
}
