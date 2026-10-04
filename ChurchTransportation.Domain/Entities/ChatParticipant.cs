namespace ChurchTransportation.Domain.Entities;

public class ChatParticipant : BaseEntity
{
    public Guid ChatRoomId { get; set; }

    public Guid UserId { get; set; }

    public DateTime JoinedAt { get; set; }

    public DateTime? LeftAt { get; set; }

    public DateTime? LastReadAt { get; set; }

    public bool IsMuted { get; set; }

    public required ChatRoom ChatRoom { get; set; }

    public required User User { get; set; }
}