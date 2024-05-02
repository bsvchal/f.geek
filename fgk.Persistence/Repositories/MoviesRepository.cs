using AutoMapper;
using fgk.Core.Abstractions;
using fgk.Core.Contracts;
using fgk.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace fgk.Persistence.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly MovieDbContext _dbContext;
        private readonly IMapper _mapper;

        public MoviesRepository(
            MovieDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<Movie>> GetAsync()
        {
            var movieEntities = await _dbContext.Movies
                .AsNoTracking()
                .ToListAsync();

            return movieEntities
                .Select(_mapper.Map<Movie>)
                .ToList();
        }
        public async Task<Movie?> GetByTitleAsync(string title)
        {
            var item = await _dbContext.Movies
                .AsNoTracking()
                .Where(item => item.Title.ToLower() == title)
                .Include(item => item.Genres)
                .Include(item => item.Keywords)
                .Include(item => item.ProductionCountries)
                .Include(item => item.Cast)
                .Include(item => item.Crew)
                .Include(item => item.Videos)
                .FirstOrDefaultAsync();

            return (item is not null) ? _mapper.Map<Movie>(item) : null;
        }

        public async Task<IEnumerable<MovieDisplay>> GetMoviesAsync(
            IEnumerable<int> movieIds)
        {
            var movieEntities = await _dbContext.Movies
                .AsNoTracking()
                .Where(movie => movieIds.Contains(movie.Id))
                .ToListAsync();

            return movieEntities
                .Select(_mapper.Map<MovieDisplay>);
        }

        public async Task<Movie?> LikeMovieAsync(Movie movie)
        {
            var amount = movie.LikesAmount + 1;

            await _dbContext.Movies
                .Where(mv => mv.Id == movie.Id)
                .ExecuteUpdateAsync(mv => mv
                    .SetProperty(mv => mv.LikesAmount, amount));

            await _dbContext.SaveChangesAsync();
            return movie;
        }

        public async Task<Movie?> UnlikeMovieAsync(Movie movie)
        {
            var amount = movie.LikesAmount - 1;
            
            await _dbContext.Movies
                .Where(mv => mv.Id == movie.Id)
                .ExecuteUpdateAsync(mv => mv
                    .SetProperty(mv => mv.LikesAmount, amount));

            await _dbContext.SaveChangesAsync();
            return movie;
        }
    }
}
