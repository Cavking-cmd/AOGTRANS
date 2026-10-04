using ChurchTransportation.Domain.Enums;

namespace ChurchTransportation.Domain.Entities;

public class DelayIncident : BaseEntity
{
    public Guid JourneyId { get; set; }

    public Guid? JourneyStopId { get; set; }

    public DelayReason Reason { get; set; }

    public string? Description { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public int? DurationMinutes { get; set; }

    public int AffectedPassengerCount { get; set; }

    public bool IsResolved { get; set; }

    public required Journey Journey { get; set; }

    public JourneyStop? JourneyStop { get; set; }
}