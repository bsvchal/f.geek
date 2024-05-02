namespace fgk.Core.Models
{
    public class Keyword
    {
        public Keyword()
        {
            Id = 0;
            Word = string.Empty;
            MoviesWithThisKeyword = null;
        }

        public Keyword(int id, string word, List<Movie>? movies)
        {
            Id = id;
            Word = word;
            MoviesWithThisKeyword = movies;
        }

        public int Id { get; private set; }
        public string Word { get; private set; }
        public List<Movie>? MoviesWithThisKeyword { get; private set; } 
    }
}