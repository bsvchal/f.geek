namespace fgk.Persistence.Entities
{
    public class CrewEntity
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Job { get; set; } = string.Empty;
        public int FromMovieId { get; set; } = 0;
        public MovieEntity? FromMovie { get; set; }
    }
}