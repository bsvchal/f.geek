using fgk.Core.Abstractions;

namespace fgk.Core.Models;

public class MovieLike
{
    public MovieLike()
    {
        Id = 0;
        LikedDateTime = DateTime.MinValue;
        TargetId = 0;
        LikedBy = null;
    }

    public MovieLike(int id, DateTime liked, int targetId, Account? likedBy)
    {
        Id = id;
        LikedDateTime = liked;
        TargetId = targetId;
        LikedBy = likedBy;
    }

    public int Id { get; private set; } 
    public DateTime LikedDateTime { get; private set; }
    public int TargetId { get; private set; } 
    public Account? LikedBy { get; private set; } 
}