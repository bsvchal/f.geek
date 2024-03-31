using fgk.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace fgk.Persistence.Configurations
{
    public class ProductionCountryConfiguration : IEntityTypeConfiguration<ProductionCountryEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ProductionCountryEntity> builder)
        {
            builder.HasKey(pc => pc.Id);

            builder.HasMany(pc => pc.MoviesFromThisCountry)
                   .WithMany(mv => mv.ProductionCountries);
        }
    }
}
