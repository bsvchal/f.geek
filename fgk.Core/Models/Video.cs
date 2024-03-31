namespace fgk.Core.Models
{
    public class Video
        (int id, string title, string youtubeURL, Movie? movie)
    {
        public int Id { get; } = id;
        public string Title { get; } = title;
        public string YouTubeURL { get; } = youtubeURL;
        public Movie? FromMovie { get; } = movie;
    }
}