using ChurchTransportation.Domain.Enums;

namespace ChurchTransportation.Domain.Entities;

public class Journey
{
    public Guid Id { get; set; }

    public Guid EventId { get; set; }

    public Guid DriverProfileId { get; set; }

    public Guid VehicleId { get; set; }

    public string? ReferenceCode { get; set; }

    public RideDirection Direction { get; set; }

    public JourneyStatus Status { get; set; } = JourneyStatus.Scheduled;

    public DateTime? PlannedStartTime { get; set; }

    public DateTime? PlannedEndTime { get; set; }

    public DateTime? ActualStartTime { get; set; }

    public DateTime? ActualEndTime { get; set; }

    public decimal? TotalDistanceKm { get; set; }

    public int? EstimatedDurationMinutes { get; set; }

    public int? TotalPassengerCount { get; set; }

    public string? RoutePolyline { get; set; }

    public string? RouteReference { get; set; }

    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public Event Event { get; set; } = null!;

    public DriverProfile DriverProfile { get; set; } = null!;

    public Vehicle Vehicle { get; set; } = null!;

    public ChatRoom? ChatRoom { get; set; }

    public ICollection<RideAssignment> RideAssignments { get; set; } = new List<RideAssignment>();

    public ICollection<JourneyStop> JourneyStops { get; set; } = new List<JourneyStop>();

    public ICollection<LocationUpdate> LocationUpdates { get; set; } = new List<LocationUpdate>();

    public ICollection<DelayIncident> DelayIncidents { get; set; } = new List<DelayIncident>();
}
