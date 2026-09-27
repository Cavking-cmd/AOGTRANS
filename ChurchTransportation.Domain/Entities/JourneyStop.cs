using ChurchTransportation.Domain.Enums;

namespace ChurchTransportation.Domain.Entities;

public class JourneyStop
{
    public Guid Id { get; set; }

    public Guid JourneyId { get; set; }

    public Guid? RideRequestId { get; set; }

    public int SequenceNumber { get; set; }

    public JourneyStopType StopType { get; set; }

    public JourneyStopStatus Status { get; set; } = JourneyStopStatus.Pending;

    public string? StopName { get; set; }

    public string Address { get; set; } = string.Empty;

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public decimal? DistanceFromPreviousKm { get; set; }

    public int? EstimatedDurationMinutes { get; set; }

    public DateTime? PlannedArrivalTime { get; set; }

    public DateTime? PlannedDepartureTime { get; set; }

    public DateTime? ActualArrivalTime { get; set; }

    public DateTime? ActualPickupTime { get; set; }

    public DateTime? ActualDropOffTime { get; set; }

    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public Journey Journey { get; set; } = null!;

    public RideRequest? RideRequest { get; set; }
}
