using fgk.Core.Contracts;
using fgk.Core.Models;

namespace fgk.Core.Abstractions
{
    public interface IMoviesRepository
    {
        Task<List<Movie>> GetAsync();
        Task<Movie?> GetByTitleAsync(string title);
        Task<Movie?> LikeMovieAsync(Movie movie);
        Task<Movie?> UnlikeMovieAsync(Movie movie);
        Task<IEnumerable<MovieDisplay>> GetMoviesAsync(IEnumerable<int> movieIds);
    }
}