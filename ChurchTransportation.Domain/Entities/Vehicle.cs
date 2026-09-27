using ChurchTransportation.Domain.Enums;

namespace ChurchTransportation.Domain.Entities;

public class Vehicle
{
    public Guid Id { get; set; }

    public string RegistrationNumber { get; set; } = string.Empty;

    public string? PlateNumber { get; set; }

    public string? Make { get; set; }

    public string? Model { get; set; }

    public int? Year { get; set; }

    public int Capacity { get; set; }

    public VehicleStatus Status { get; set; } = VehicleStatus.Available;

    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public ICollection<DriverVehicle> DriverVehicles { get; set; } = new List<DriverVehicle>();

    public ICollection<Journey> Journeys { get; set; } = new List<Journey>();
}
