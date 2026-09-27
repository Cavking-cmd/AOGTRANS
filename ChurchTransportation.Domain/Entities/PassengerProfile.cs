namespace ChurchTransportation.Domain.Entities;

public class PassengerProfile
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string? PhoneNumber { get; set; }

    public string? EmergencyContactName { get; set; }

    public string? EmergencyContactPhone { get; set; }

    public string? DefaultPickupAddress { get; set; }

    public decimal? DefaultPickupLatitude { get; set; }

    public decimal? DefaultPickupLongitude { get; set; }

    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public User User { get; set; } = null!;

    public ICollection<RideRequest> RideRequests { get; set; } = new List<RideRequest>();
}
