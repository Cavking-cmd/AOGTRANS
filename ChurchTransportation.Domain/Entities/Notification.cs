using ChurchTransportation.Domain.Enums;

namespace ChurchTransportation.Domain.Entities;

public class Notification : BaseEntity
{
    public Guid UserId { get; set; }

    public NotificationType Type { get; set; }

    public required string Title { get; set; }

    public required string Message { get; set; }

    public Guid? RideRequestId { get; set; }

    public Guid? JourneyId { get; set; }

    public string? Payload { get; set; }

    public bool IsRead { get; set; }

    public DateTime? ReadAt { get; set; }

    public required User User { get; set; }
}