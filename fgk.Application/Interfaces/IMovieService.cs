using fgk.Core.Contracts;
using fgk.Core.Models;

namespace fgk.Application.Interfaces
{
    public interface IMovieService
    {
        Task<Movie?> GetMovieByTitleQuery(string titleQuery);
        Task<List<Movie>> GetMoviesByTitle(string title);
        Task<Movie?> LikeMovieAsync(Movie movie);
        Task<Movie?> UnikeMovieAsync(Movie movie);
        Task<IEnumerable<MovieDisplay>> GetAllLikedMoviesAsync(
            IEnumerable<MovieLike> likes, int maximumAmount);
    }
}