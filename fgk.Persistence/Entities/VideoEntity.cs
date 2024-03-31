namespace fgk.Persistence.Entities
{
    public class VideoEntity
    {
        public int Id { get; set; } = 0;
        public string Title { get; set; } = string.Empty;
        public string YouTubeURL { get; set; } = string.Empty;
        public int FromMovieId { get; set; } = 0;
        public MovieEntity? FromMovie { get; set; }
    } 
}