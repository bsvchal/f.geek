namespace fgk.Core.Models
{
    public class Crew
    {
        public Crew()
        {
            Id = 0;
            Name = string.Empty;
            Department = string.Empty;
            Job = string.Empty;
            FromMovie = null;
        }

        public Crew(int id, string name, string department, string job, Movie? movie)
        {
            Id = id;
            Name = name;
            Department = department;
            Job = job;
            FromMovie = movie;
        }

        public int Id { get; private set; }
        public string Name { get; private set; } 
        public string Department { get; private set; }
        public string Job { get; private set; } 
        public Movie? FromMovie { get; private set; }
    }
}