using fgk.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace fgk.Persistence.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<MovieEntity>
    {
        public void Configure(EntityTypeBuilder<MovieEntity> builder)
        {
            builder.HasKey(mv => mv.Id);

            builder.HasMany(mv => mv.Genres)
                   .WithMany(gn => gn.MoviesOfThisGenre);

            builder.HasMany(mv => mv.ProductionCountries)
                   .WithMany(pc => pc.MoviesFromThisCountry);

            builder.HasMany(mv => mv.Keywords)
                   .WithMany(kw => kw.MoviesWithThisKeyword);

            builder.HasMany(mv => mv.Cast)
                   .WithOne(cs => cs.FromMovie)
                   .HasForeignKey(cs => cs.FromMovieId);

            builder.HasMany(mv => mv.Crew)
                   .WithOne(cr => cr.FromMovie)
                   .HasForeignKey(cr => cr.FromMovieId);

            builder.HasMany(mv => mv.Videos)
                   .WithOne(vd => vd.FromMovie)
                   .HasForeignKey(vd => vd.FromMovieId);
        }
    }
}
