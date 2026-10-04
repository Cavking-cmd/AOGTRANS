using ChurchTransportation.Domain.Enums;

namespace ChurchTransportation.Domain.Entities;

public class Vehicle : BaseEntity
{
    public required string RegistrationNumber { get; set; }

    public string? PlateNumber { get; set; }

    public string? Make { get; set; }

    public string? Model { get; set; }

    public int? Year { get; set; }

    public int Capacity { get; set; }

    public VehicleStatus Status { get; set; } = VehicleStatus.Available;

    public string? Notes { get; set; }

    public ICollection<DriverVehicle> DriverVehicles { get; set; } = new List<DriverVehicle>();

    public ICollection<Journey> Journeys { get; set; } = new List<Journey>();
}