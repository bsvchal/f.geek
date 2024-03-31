using fgk.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace fgk.Persistence.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<GenreEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<GenreEntity> builder)
        {
            builder.HasKey(gn => gn.Id);

            builder.HasMany(gn => gn.MoviesOfThisGenre)
                   .WithMany(mv => mv.Genres);
        }
    }
}
