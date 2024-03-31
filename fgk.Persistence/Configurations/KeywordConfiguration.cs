using fgk.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace fgk.Persistence.Configurations
{
    public class KeywordConfiguration : IEntityTypeConfiguration<KeywordEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<KeywordEntity> builder)
        {
            builder.HasKey(kw => kw.Id);

            builder.HasMany(kw => kw.MoviesWithThisKeyword)
                   .WithMany(mv => mv.Keywords);
        }
    }
}
