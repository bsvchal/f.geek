namespace fgk.Core.Models;

public class Movie(
    int id, string title, DateTime releaseDate,
    int runtime, string shortDescription, string description,
    string? tagline, long budget, long revenue, string rated,
    string posterURL, IEnumerable<Genre> genres, int likesAmount,
    IEnumerable<Keyword> keywords, IEnumerable<ProductionCountry> productionCountries,
    IEnumerable<Cast> cast, IEnumerable<Crew> crew, IEnumerable<Video>? videos,
    double? iMDbRating, int? rottenTomatoesRating, int? metacriticRating)
{
    public static string DefaultPosterURL { get; } = string.Empty;

    public int Id { get; private set; } = id;
    public string Title { get; private set; } = title;
    public DateTime ReleaseDate { get; private set; } = releaseDate;
    public int Runtime { get; private set; } = runtime;
    public string ShortDescription { get; private set; } = shortDescription;
    public string Description { get; private set; } = description;
    public string? Tagline { get; private set; } = tagline;
    public long Budget { get; private set; } = budget;
    public long Revenue { get; private set; } = revenue;
    public string Rated { get; private set; } = rated;
    public string PosterURL { get; private set; } = posterURL;
    public IEnumerable<Genre> Genres { get; private set; } = genres;
    public int LikesAmount { get; private set; } = likesAmount;
    public IEnumerable<Keyword> Keywords { get; private set; } = keywords;
    public IEnumerable<ProductionCountry> ProductionCountries { get; private set; } = productionCountries;
    public IEnumerable<Cast> Cast { get; private set; } = cast;
    public IEnumerable<Crew> Crew { get; private set; } = crew;
    public IEnumerable<Video>? Videos { get; private set; } = videos;
    public double? IMDbRating { get; private set; } = iMDbRating;
    public int? RottenTomatoesRating { get; private set; } = rottenTomatoesRating;
    public int? MetacriticRating { get; private set; } = metacriticRating;

    public string HoursMinutesRuntime() => (Runtime < 60) ? 
            $"{Runtime} min." : $"{Runtime / 60} h. {Runtime % 60} min.";
    public string TitleQuery() => Title.ToLower().Replace(" ", "+");
    public void Like() => ++LikesAmount;
    public void Unlike() => --LikesAmount;
}
