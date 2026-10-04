using ChurchTransportation.Domain.Enums;

namespace ChurchTransportation.Domain.Entities;

public class RideRequest : BaseEntity
{
    public Guid PassengerProfileId { get; set; }

    public Guid EventId { get; set; }

    public required string PickupAddress { get; set; }

    public decimal PickupLatitude { get; set; }

    public decimal PickupLongitude { get; set; }

    public RideDirection Direction { get; set; }

    public RideRequestStatus Status { get; set; } = RideRequestStatus.Pending;

    public RideRequestSource Source { get; set; } = RideRequestSource.MobileApp;

    public int PassengerCount { get; set; } = 1;

    public string? Notes { get; set; }

    public DateTime RequestedAt { get; set; }

    public DateTime? CancelledAt { get; set; }

    public string? CancellationReason { get; set; }

    public required PassengerProfile PassengerProfile { get; set; }

    public required Event Event { get; set; }

    public RideAssignment? RideAssignment { get; set; }

    public ICollection<JourneyStop> JourneyStops { get; set; } = new List<JourneyStop>();
}