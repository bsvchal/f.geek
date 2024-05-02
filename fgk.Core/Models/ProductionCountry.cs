namespace fgk.Core.Models
{
    public class ProductionCountry
    {
        public ProductionCountry()
        {
            Id = 0;
            Name = string.Empty;
            MoviesFromThisCountry = null;
        }

        private ProductionCountry(int id, string name, List<Movie>? movies)
        {
            Id = id;
            Name = name;
            MoviesFromThisCountry = movies;
        }

        public int Id { get; private set; } 
        public string Name { get; private set; }
        public List<Movie>? MoviesFromThisCountry { get; private set; }

        public static ProductionCountry Create(int id, string name, List<Movie>? movies)
            => new (id, name, movies);
    } 
}