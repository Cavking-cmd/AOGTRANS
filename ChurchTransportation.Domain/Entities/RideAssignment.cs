using ChurchTransportation.Domain.Enums;

namespace ChurchTransportation.Domain.Entities;

public class RideAssignment
{
    public Guid Id { get; set; }

    public Guid RideRequestId { get; set; }

    public Guid JourneyId { get; set; }

    public RideAssignmentStatus Status { get; set; } = RideAssignmentStatus.Assigned;

    public DateTime AssignedAt { get; set; }

    public DateTime? AcceptedAt { get; set; }

    public DateTime? CancelledAt { get; set; }

    public decimal? MatchingScore { get; set; }

    public string? AssignmentReason { get; set; }

    public Guid? AssignedByUserId { get; set; }

    public string? ReassignmentReason { get; set; }

    public DateTime? ReassignedAt { get; set; }

    public Guid? ReassignedFromAssignmentId { get; set; }

    public Guid? ReassignedToAssignmentId { get; set; }

    public RideRequest RideRequest { get; set; } = null!;

    public Journey Journey { get; set; } = null!;

    public RideAssignment? ReassignedFromAssignment { get; set; }
}
