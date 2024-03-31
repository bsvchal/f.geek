using fgk.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace fgk.Persistence.Configurations
{
    public class MovieLikeConfiguration : IEntityTypeConfiguration<MovieLikeEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<MovieLikeEntity> builder)
        {
            builder.HasKey(ml => ml.Id);

            builder.HasOne(ml => ml.Account)
                   .WithMany(ac => ac.Likes)
                   .HasForeignKey(ml => ml.AccountId);
        }
    }
}
