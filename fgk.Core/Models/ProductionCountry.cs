namespace fgk.Core.Models
{
    public class ProductionCountry
        (int id, string name, List<Movie>? movies)
    {
        public int Id { get; } = id; 
        public string Name { get; } = name;
        public List<Movie>? MoviesFromThisCountry { get; } = movies;
    } 
}