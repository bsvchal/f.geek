using System.Security.Cryptography;
using System.Text;

namespace fgk.Core.Models
{
    public class Movie 
        (int id, string title, DateTime releaseDate, int runtime,
         string shortDescription, string description, string? tagline, long budget,
         long revenue, string rated, string? posterURL, int likesAmount, 
         IEnumerable<Genre> genres, IEnumerable<Keyword> keywords,
         IEnumerable<ProductionCountry> countries, 
         IEnumerable<Cast> cast, IEnumerable<Crew> crew,
         IEnumerable<Video>? videos, double? imdbRating,
         int? rottenTomatoesRating, int? metacriticRating) 
    {
        public static string DefaultPosterURL { get; } = string.Empty;

        private readonly List<Genre> _genres = genres.ToList();
        private readonly List<Keyword> _keywords = keywords.ToList();
        private readonly List<ProductionCountry> _countries = countries.ToList();
        private readonly List<Cast> _cast = cast.ToList();
        private readonly List<Crew> _crew = crew.ToList();
        private List<Video> _videos = (videos is null) ? [] : videos.ToList();

        public int Id { get; } = id;
        public string Title { get; } = title;
        public DateTime ReleaseDate { get; } = releaseDate;
        public int Runtime { get; } = runtime;
        public string ShortDescription { get; } = shortDescription;
        public string Description { get; } = description;
        public string? Tagline { get; private set; } = tagline;
        public long Budget { get; } = budget;
        public long Revenue { get; } = revenue;
        public string Rated { get; } = rated;
        public string PosterURL { get; private set; } = (posterURL is null) ? DefaultPosterURL : posterURL;
        public IReadOnlyList<Genre> Genres { get => _genres.AsReadOnly(); }
        public int LikesAmount { get; private set; } = likesAmount;
        public IReadOnlyList<Keyword> Keywords { get => _keywords.AsReadOnly(); }
        public IReadOnlyList<ProductionCountry> ProductionCountries { get => _countries.AsReadOnly(); }
        public IReadOnlyList<Cast> Cast { get => _cast.AsReadOnly(); }
        public IReadOnlyList<Crew> Crew { get => _crew.AsReadOnly(); }
        public IReadOnlyList<Video>? Videos { get => _videos.AsReadOnly(); }
        public double? IMDbRating { get; private set; } = imdbRating;
        public int? RottenTomatoesRating { get; private set; } = rottenTomatoesRating;
        public int? MetacriticRating { get; private set; } = metacriticRating;

        public string HoursMinutesRuntime()
        {
            return (Runtime < 60) ? 
                $"{Runtime} min." : $"{Runtime / 60} h. {Runtime % 60} min.";
        }

        public string TitleQuery()
        {
            return Title.ToLower().Replace(" ", "+");
        }
         
        public void Like() => ++LikesAmount;
        public void Unlike() => --LikesAmount;  
    }
}
