using ChurchTransportation.Domain.Enums;

namespace ChurchTransportation.Domain.Entities;

public class Event
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string? LocationName { get; set; }

    public string? Address { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public EventStatus Status { get; set; } = EventStatus.Draft;

    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public ICollection<RideRequest> RideRequests { get; set; } = new List<RideRequest>();

    public ICollection<Journey> Journeys { get; set; } = new List<Journey>();
}
