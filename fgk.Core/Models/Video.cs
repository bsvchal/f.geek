namespace fgk.Core.Models
{
    public class Video
    {
        public Video()
        {
            Id = 0;
            Title = string.Empty;
            YouTubeURL = string.Empty;
            FromMovie = null;
        }

        public Video(int id, string title, string url, Movie? movie)
        {
            Id = id;
            Title = title;
            YouTubeURL = url;
            FromMovie = movie;
        }

        public int Id { get; private set; } 
        public string Title { get; private set; }
        public string YouTubeURL { get; private set; }
        public Movie? FromMovie { get; private set; } 
    }
}