namespace fgk.Core.Models
{
    public class Cast
        (int id, string name, string character, Movie? movie, int order)
    {
        public int Id { get; } = id;
        public string Name { get; } = name;
        public string Character { get; } = character;
        public Movie? FromMovie { get; } = movie;
        public int Order { get; } = order;
    }
}