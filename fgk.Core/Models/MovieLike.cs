using fgk.Core.Abstractions;

namespace fgk.Core.Models
{
    public class MovieLike
        (int id, DateTime likeDateTime, int targetId, Account? account)
    {
        public int Id { get; } = id;
        public DateTime LikedDateTime { get; } = likeDateTime;
        public int TargetId { get; } = targetId;
        public Account? LikedBy { get; } = account;
    }
}