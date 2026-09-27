namespace ChurchTransportation.Domain.Entities;

public class ChatMessage
{
    public Guid Id { get; set; }

    public Guid ChatRoomId { get; set; }

    public Guid SenderUserId { get; set; }

    public string Content { get; set; } = string.Empty;

    public DateTime SentAt { get; set; }

    public DateTime? EditedAt { get; set; }

    public bool IsDeleted { get; set; }

    public ChatRoom ChatRoom { get; set; } = null!;

    public User Sender { get; set; } = null!;
}
