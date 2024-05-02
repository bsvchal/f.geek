namespace fgk.Core.Models
{
    public class Genre
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public List<Movie>? MoviesOfThisGenre { get; private set; }

        public Genre(int id, string name, List<Movie>? movies)
        {
            Id = id;
            Name = name;
            MoviesOfThisGenre = movies;
        }

        public Genre()
        {
            Name = string.Empty;   
        }
    }
}