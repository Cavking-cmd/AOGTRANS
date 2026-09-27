using ChurchTransportation.Domain.Enums;
using ChurchTransportation.Domain.Entities;

namespace ChurchTransportation.Application.Interfaces.Repositories;

public interface IVehicleRepository : IRepository<Vehicle>
{
    Task<Vehicle?> GetByRegistrationNumberAsync(string registrationNumber, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Vehicle>> GetByStatusAsync(VehicleStatus status, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Vehicle>> GetAvailableForEventAsync(
        Guid eventId,
        RideDirection direction,
        int requiredCapacity,
        CancellationToken cancellationToken = default);

    Task<Vehicle?> GetByIdWithDriverVehiclesAsync(Guid id, CancellationToken cancellationToken = default);
}
