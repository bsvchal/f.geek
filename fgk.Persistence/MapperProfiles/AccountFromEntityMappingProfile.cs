using AutoMapper;
using fgk.Core.Models;
using fgk.Persistence.Entities;

namespace fgk.Persistence.MapperProfiles;

public class AccountFromEntityMappingProfile : Profile
{
    public AccountFromEntityMappingProfile()
    {
        CreateMap<AccountEntity, Account>()
            .ForMember(ae => ae.Likes, opt => opt.MapFrom(
                src => src.Likes.Select(le => new MovieLike(le.Id, le.LikedDateTime, le.TargetId, null))));
    }
}
