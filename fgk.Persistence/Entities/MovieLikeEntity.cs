namespace fgk.Persistence.Entities
{
    public class MovieLikeEntity
    {
        public int Id { get; set; } = 0;
        public DateTime LikedDateTime { get; set; } = DateTime.MinValue;
        public int TargetId { get; set; } = 0;
        public int AccountId { get; set; } = 0;
        public AccountEntity? Account { get; set; }
    }
}