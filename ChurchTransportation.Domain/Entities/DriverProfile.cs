using ChurchTransportation.Domain.Enums;

namespace ChurchTransportation.Domain.Entities;

public class DriverProfile : BaseEntity
{
    public Guid UserId { get; set; }

    public string? LicenseNumber { get; set; }

    public DateTime? LicenseExpiryDate { get; set; }

    public DriverStatus Status { get; set; } = DriverStatus.OffDuty;

    public string? Notes { get; set; }

    public decimal? Rating { get; set; }

    public int TotalTripsCompleted { get; set; }

    public required User User { get; set; }

    public ICollection<DriverVehicle> DriverVehicles { get; set; } = new List<DriverVehicle>();

    public ICollection<Journey> Journeys { get; set; } = new List<Journey>();
}