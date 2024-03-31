using fgk.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace fgk.Persistence.Configurations
{
    public class CrewConfiguration : IEntityTypeConfiguration<CrewEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CrewEntity> builder)
        {
            builder.HasKey(cr => cr.Id);

            builder.HasOne(cr => cr.FromMovie)
                   .WithMany(mv => mv.Crew)
                   .HasForeignKey(cr => cr.FromMovieId);
        }
    }
}
