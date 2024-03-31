namespace fgk.Persistence.Entities
{
    public class ProductionCountryEntity
    {
        public int Id { get; set; } = 0; 
        public string Name { get; set; } = string.Empty;
        public List<MovieEntity> MoviesFromThisCountry { get; set; } = [];
    }
}