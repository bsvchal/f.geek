using fgk.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace fgk.Persistence.Configurations
{
    public class VideoConfiguration : IEntityTypeConfiguration<VideoEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<VideoEntity> builder)
        {
            builder.HasKey(vd => vd.Id);

            builder.HasOne(vd => vd.FromMovie)
                   .WithMany(mv => mv.Videos)
                   .HasForeignKey(vd => vd.FromMovieId);
        }
    }
}
