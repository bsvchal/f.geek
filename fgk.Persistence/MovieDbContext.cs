using fgk.Persistence.Configurations;
using fgk.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace fgk.Persistence
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) 
            : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<MovieEntity> Movies { get; set; }
        public DbSet<CastEntity> Cast { get; set; }
        public DbSet<CrewEntity> Crew { get; set; }
        public DbSet<GenreEntity> Genres { get; set; }
        public DbSet<KeywordEntity> Keywords { get; set; }
        public DbSet<ProductionCountryEntity> ProductionCountries { get; set; }
        public DbSet<VideoEntity> Videos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CastConfiguration());
            modelBuilder.ApplyConfiguration(new CrewConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new KeywordConfiguration());
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new ProductionCountryConfiguration());
            modelBuilder.ApplyConfiguration(new VideoConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
