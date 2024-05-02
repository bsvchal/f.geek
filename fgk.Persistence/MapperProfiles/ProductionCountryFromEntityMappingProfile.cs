using AutoMapper;
using fgk.Core.Models;
using fgk.Persistence.Entities;

namespace fgk.Persistence.MapperProfiles;

public class ProductionCountryFromEntityMappingProfile : Profile
{
    public ProductionCountryFromEntityMappingProfile()
    {
        CreateMap<ProductionCountryEntity, ProductionCountry>()
            .ForMember(pc => pc.MoviesFromThisCountry, opt => opt.Ignore());
    }
}