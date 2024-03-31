namespace fgk.Core.Models
{
    public class Keyword
        (int id, string word, List<Movie>? movies)
    {
        public int Id { get; } = id;
        public string Word { get; } = word;
        public List<Movie>? MoviesWithThisKeyword { get; } = movies;
    }
}