namespace fgk.Core.Models
{
    public class Genre
        (int id, string name, List<Movie>? movies)
    {
        public int Id { get; } = id;
        public string Name { get; } = name;
        public List<Movie>? MoviesOfThisGenre { get; } = movies;
    }
}