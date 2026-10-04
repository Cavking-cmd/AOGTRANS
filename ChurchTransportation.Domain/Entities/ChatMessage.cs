namespace ChurchTransportation.Domain.Entities;

public class ChatMessage : BaseEntity
{
    public Guid ChatRoomId { get; set; }

    public Guid SenderId { get; set; }

    public required string Content { get; set; }

    public DateTime SentAt { get; set; }

    public DateTime? EditedAt { get; set; }

    public required ChatRoom ChatRoom { get; set; }

    public required User Sender { get; set; }
}