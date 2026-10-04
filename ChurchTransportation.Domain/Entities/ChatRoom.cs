using ChurchTransportation.Domain.Enums;

namespace ChurchTransportation.Domain.Entities;

public class ChatRoom : BaseEntity
{
    public ChatRoomType Type { get; set; } = ChatRoomType.General;

    public required string Name { get; set; }

    public string? Description { get; set; }

    public Guid? JourneyId { get; set; }

    public Guid? CreatedByUserId { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime? ClosedAt { get; set; }

    public Journey? Journey { get; set; }

    public ICollection<ChatParticipant> ChatParticipants { get; set; } = new List<ChatParticipant>();

    public ICollection<ChatMessage> ChatMessages { get; set; } = new List<ChatMessage>();
}