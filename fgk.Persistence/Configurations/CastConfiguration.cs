using fgk.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace fgk.Persistence.Configurations
{
    public class CastConfiguration : IEntityTypeConfiguration<CastEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CastEntity> builder)
        {
            builder.HasKey(cs => cs.Id);

            builder.HasOne(cs => cs.FromMovie)
                   .WithMany(mv => mv.Cast)
                   .HasForeignKey(cs => cs.FromMovieId);
        }
    }
}
