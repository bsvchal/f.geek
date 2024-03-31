namespace fgk.Core.Models
{
    public class Crew
        (int id, string name, string department, string job, Movie? movie)
    {
        public int Id { get; } = id;
        public string Name { get; } = name;
        public string Department { get; } = department;
        public string Job { get; } = job;
        public Movie? FromMovie { get; } = movie;
    }
}