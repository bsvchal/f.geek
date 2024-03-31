using fgk.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace fgk.Persistence.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<AccountEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<AccountEntity> builder)
        {
            builder.HasKey(mv => mv.Id);
            
            builder.HasMany(mv => mv.Likes)
                   .WithOne(ml => ml.Account)
                   .HasForeignKey(ml => ml.AccountId);
        }
    }
}
