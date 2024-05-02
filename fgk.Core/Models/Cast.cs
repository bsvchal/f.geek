namespace fgk.Core.Models
{
    public class Cast
    {
        public Cast()
        {
            Id = 0;
            Name = string.Empty;
            Character = string.Empty;
            FromMovie = null;
            Order = 0;
        }

        public Cast(int id, string name, string character, Movie? movie, int order)
        {
            Id = id;
            Name = name;
            Character = character;
            FromMovie = movie;
            Order = order;
        }

        public int Id { get; private set; }
        public string Name { get; private set; } 
        public string Character { get; private set; }
        public Movie? FromMovie { get; private set; }
        public int Order { get; private set; } 
    }
}