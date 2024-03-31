namespace fgk.Persistence.Entities
{
    public class GenreEntity
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;

        public List<MovieEntity> MoviesOfThisGenre { get; set; } = [];
    }
}