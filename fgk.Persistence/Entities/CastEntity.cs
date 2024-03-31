namespace fgk.Persistence.Entities
{
    public class CastEntity
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Character { get; set; } = string.Empty;
        public int Order { get; set; } = 0;
        public int FromMovieId { get; set; } = 0;
        public MovieEntity? FromMovie { get; set; }
    }
}