namespace fgk.Persistence.Entities
{
    public class AccountEntity
    {
        public int Id { get; set; } = 0;
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public List<MovieLikeEntity> Likes { get; set; } = [];

    }
}
