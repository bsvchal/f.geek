using AutoMapper;
using fgk.Core.Models;
using fgk.Persistence.Entities;

namespace fgk.Persistence.MapperProfiles;

public class MovieFromEntityMappingProfile : Profile
{
    public MovieFromEntityMappingProfile()
    {
        CreateMap<MovieEntity, Movie>()
            .ForMember(mv => mv.Genres, opt => opt.MapFrom(
                src => src.Genres.Select(gne => new Genre(gne.Id, gne.Name, null))))
            .ForMember(mv => mv.Keywords, opt => opt.MapFrom(
                src => src.Keywords.Select(kwe => new Keyword(kwe.Id, kwe.Word, null))))
            .ForMember(mv => mv.ProductionCountries, opt => opt.MapFrom(
                src => src.ProductionCountries.Select(pce => ProductionCountry.Create(pce.Id, pce.Name, null))))
            .ForMember(mv => mv.Cast, opt => opt.MapFrom(
                src => src.Cast.Select(cte => new Cast(cte.Id, cte.Name, cte.Character, null, cte.Order))))
            .ForMember(mv => mv.Crew, opt => opt.MapFrom(
                src => src.Crew.Select(item => new Crew(item.Id, item.Name, item.Department, item.Job, null))))
            .ForMember(mv => mv.Videos, opt => opt.MapFrom(
                src => src.Videos == null ? null : src.Videos.Select(vde => new Video(vde.Id, vde.Title, vde.YouTubeURL, null))));
    }
}
