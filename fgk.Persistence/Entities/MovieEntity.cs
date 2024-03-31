namespace fgk.Persistence.Entities
{
    public class MovieEntity
    {
        public int Id { get; set; } = 0;
        public string Title { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; } = DateTime.MinValue;
        public int Runtime { get; set; } = 0;
        public string ShortDescription { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? Tagline { get; set; }
        public long Budget { get; set; } = 0;
        public long Revenue { get; set; } = 0;
        public string Rated { get; set; } = string.Empty;
        public string? PosterURL { get; set; } = string.Empty;
        public HashSet<GenreEntity> Genres { get; set; } = [];
        public int LikesAmount { get; set; } = 0;
        public HashSet<KeywordEntity> Keywords { get; set; } = [];
        public HashSet<ProductionCountryEntity> ProductionCountries { get; set; } = [];
        public HashSet<CastEntity> Cast { get; set; } = [];
        public HashSet<CrewEntity> Crew { get; set; } = [];
        public HashSet<VideoEntity>? Videos { get; set; } = [];
        public int? IMDbRating { get; set; }
        public int? RottenTomatoesRating { get; set; }
        public int? MetacriticRating { get; set; }
    }
}
