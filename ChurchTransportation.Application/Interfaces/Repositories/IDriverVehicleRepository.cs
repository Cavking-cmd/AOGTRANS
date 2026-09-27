using ChurchTransportation.Domain.Entities;

namespace ChurchTransportation.Application.Interfaces.Repositories;

public interface IDriverVehicleRepository : IRepository<DriverVehicle>
{
    Task<IReadOnlyList<DriverVehicle>> GetByDriverProfileIdAsync(
        Guid driverProfileId,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<DriverVehicle>> GetByVehicleIdAsync(
        Guid vehicleId,
        CancellationToken cancellationToken = default);

    Task<DriverVehicle?> GetCurrentByDriverProfileIdAsync(
        Guid driverProfileId,
        CancellationToken cancellationToken = default);

    Task<DriverVehicle?> GetCurrentByVehicleIdAsync(
        Guid vehicleId,
        CancellationToken cancellationToken = default);
}
