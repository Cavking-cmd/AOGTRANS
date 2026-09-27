using ChurchTransportation.Domain.Enums;
using ChurchTransportation.Domain.Entities;

namespace ChurchTransportation.Application.Interfaces.Repositories;

public interface IDriverRepository : IRepository<DriverProfile>
{
    Task<DriverProfile?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<DriverProfile>> GetByStatusAsync(DriverStatus status, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<DriverProfile>> GetAvailableForEventAsync(
        Guid eventId,
        RideDirection direction,
        CancellationToken cancellationToken = default);

    Task<DriverProfile?> GetByIdWithVehiclesAsync(Guid id, CancellationToken cancellationToken = default);

    Task<DriverProfile?> GetByIdWithJourneysAsync(Guid id, CancellationToken cancellationToken = default);
}
