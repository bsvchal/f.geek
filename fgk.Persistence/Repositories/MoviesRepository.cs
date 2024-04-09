using fgk.Core.Abstractions;
using fgk.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace fgk.Persistence.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly MovieDbContext dbContext;

        public MoviesRepository(MovieDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Movie>> GetAsync()
        {
            var movieEntities = await dbContext.Movies
                .AsNoTracking()
                .ToListAsync();

            return movieEntities
                .Select(item =>
                new Movie(
                        item.Id,
                        item.Title,
                        item.ReleaseDate,
                        item.Runtime,
                        item.ShortDescription,
                        item.Description,
                        item.Tagline,
                        item.Budget,
                        item.Revenue,
                        item.Rated,
                        item.PosterURL,
                        item.LikesAmount,
                        item.Genres.Select(item => new Genre(item.Id, item.Name, null)),
                        item.Keywords.Select(item => new Keyword(item.Id, item.Word, null)),
                        item.ProductionCountries.Select(item => new ProductionCountry(item.Id, item.Name, null)),
                        item.Cast.Select(item => new Cast(item.Id, item.Name, item.Character, null, item.Order)),
                        item.Crew.Select(item => new Crew(item.Id, item.Name, item.Department, item.Job, null)),
                        item.Videos?.Select(item => new Video(item.Id, item.Title, item.YouTubeURL, null)),
                        item.IMDbRating,
                        item.RottenTomatoesRating,
                        item.MetacriticRating
                    )
                )
                .ToList();
        }
        public async Task<Movie?> GetByTitleAsync(string title)
        {
            var item = await dbContext.Movies.AsNoTracking()
                .Where(item => item.Title.ToLower() == title)
                .Include(item => item.Genres)
                .Include(item => item.Keywords)
                .Include(item => item.ProductionCountries)
                .Include(item => item.Cast)
                .Include(item => item.Crew)
                .Include(item => item.Videos)
                .FirstOrDefaultAsync();

            return (item is not null) ? new Movie(
                        item.Id,
                        item.Title,
                        item.ReleaseDate,
                        item.Runtime,
                        item.ShortDescription,
                        item.Description,
                        item.Tagline,
                        item.Budget,
                        item.Revenue,
                        item.Rated,
                        item.PosterURL,
                        item.LikesAmount,
                        item.Genres.Select(item => new Genre(item.Id, item.Name, null)),
                        item.Keywords.Select(item => new Keyword(item.Id, item.Word, null)),
                        item.ProductionCountries.Select(item => new ProductionCountry(item.Id, item.Name, null)),
                        item.Cast.Select(item => new Cast(item.Id, item.Name, item.Character, null, item.Order)),
                        item.Crew.Select(item => new Crew(item.Id, item.Name, item.Department, item.Job, null)),
                        item.Videos?.Select(item => new Video(item.Id, item.Title, item.YouTubeURL, null)),
                        item.IMDbRating,
                        item.RottenTomatoesRating,
                        item.MetacriticRating
                    ) : null;
        }

        public async Task<Movie?> LikeMovieAsync(Movie movie)
        {
            var amount = movie.LikesAmount + 1;

            await dbContext.Movies
                .Where(mv => mv.Id == movie.Id)
                .ExecuteUpdateAsync(mv => mv
                    .SetProperty(mv => mv.LikesAmount, amount));

            await dbContext.SaveChangesAsync();
            return movie;
        }

        public async Task<Movie?> UnlikeMovieAsync(Movie movie)
        {
            var amount = movie.LikesAmount - 1;
            
            await dbContext.Movies
                .Where(mv => mv.Id == movie.Id)
                .ExecuteUpdateAsync(mv => mv
                    .SetProperty(mv => mv.LikesAmount, amount));

            await dbContext.SaveChangesAsync();
            return movie;
        }
    }
}
