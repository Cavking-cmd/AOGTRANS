namespace ChurchTransportation.Domain.Entities;

public class PassengerProfile : BaseEntity
{
    public Guid UserId { get; set; }

    public string? PhoneNumber { get; set; }

    public string? EmergencyContactName { get; set; }

    public string? EmergencyContactPhone { get; set; }

    public string? DefaultPickupAddress { get; set; }

    public decimal? DefaultPickupLatitude { get; set; }

    public decimal? DefaultPickupLongitude { get; set; }

    public string? Notes { get; set; }

    public required User User { get; set; }

    public ICollection<RideRequest> RideRequests { get; set; } = new List<RideRequest>();
}