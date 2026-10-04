namespace ChurchTransportation.Domain.Entities;

public class DriverVehicle : BaseEntity
{
    public Guid DriverProfileId { get; set; }

    public Guid VehicleId { get; set; }

    public bool IsPrimary { get; set; }

    public DateTime? AssignedFrom { get; set; }

    public DateTime? AssignedTo { get; set; }

    public string? Notes { get; set; }

    public required DriverProfile DriverProfile { get; set; }

    public required Vehicle Vehicle { get; set; }
}