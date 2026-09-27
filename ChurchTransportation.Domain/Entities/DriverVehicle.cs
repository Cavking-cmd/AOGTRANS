namespace ChurchTransportation.Domain.Entities;

public class DriverVehicle
{
    public Guid Id { get; set; }

    public Guid DriverProfileId { get; set; }

    public Guid VehicleId { get; set; }

    public bool IsPrimary { get; set; }

    public DateTime? AssignedFrom { get; set; }

    public DateTime? AssignedTo { get; set; }

    public string? Notes { get; set; }

    public DriverProfile DriverProfile { get; set; } = null!;

    public Vehicle Vehicle { get; set; } = null!;
}
