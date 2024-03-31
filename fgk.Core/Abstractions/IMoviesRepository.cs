using fgk.Core.Models;

namespace fgk.Core.Abstractions
{
    public interface IMoviesRepository
    {
        Task<List<Movie>> GetAsync();
        Task<Movie?> GetByTitleAsync(string title);
        Task<Movie?> LikeMovieAsync(Movie movie);
    }
}