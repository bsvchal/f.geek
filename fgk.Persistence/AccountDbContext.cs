using fgk.Persistence.Configurations;
using fgk.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace fgk.Persistence
{
    public class AccountDbContext : DbContext
    {
        public AccountDbContext(DbContextOptions<AccountDbContext> options) 
            : base(options) { }

        public DbSet<AccountEntity> Accounts { get; set; }
        public DbSet<MovieLikeEntity> MovieLikes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new MovieLikeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
