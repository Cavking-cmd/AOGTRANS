namespace ChurchTransportation.Domain.Entities;

public class ChatParticipant
{
    public Guid Id { get; set; }

    public Guid ChatRoomId { get; set; }

    public Guid UserId { get; set; }

    public DateTime JoinedAt { get; set; }

    public DateTime? LeftAt { get; set; }

    public DateTime? LastReadAt { get; set; }

    public bool IsMuted { get; set; }

    public ChatRoom ChatRoom { get; set; } = null!;

    public User User { get; set; } = null!;
}
