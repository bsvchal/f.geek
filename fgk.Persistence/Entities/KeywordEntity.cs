namespace fgk.Persistence.Entities
{
    public class KeywordEntity
    {
        public int Id { get; set; } = 0;
        public string Word { get; set; } = string.Empty;
        public List<MovieEntity> MoviesWithThisKeyword { get; set; } = [];
    }
}