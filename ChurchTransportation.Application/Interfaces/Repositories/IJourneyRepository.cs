using ChurchTransportation.Domain.Enums;
using ChurchTransportation.Domain.Entities;

namespace ChurchTransportation.Application.Interfaces.Repositories;

public interface IJourneyRepository : IRepository<Journey>
{
    Task<Journey?> GetByIdWithStopsAsync(Guid id, CancellationToken cancellationToken = default);

    Task<Journey?> GetByIdWithAssignmentsAsync(Guid id, CancellationToken cancellationToken = default);

    Task<Journey?> GetByReferenceCodeAsync(string referenceCode, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Journey>> GetByDriverProfileIdAsync(
        Guid driverProfileId,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Journey>> GetByEventIdAsync(
        Guid eventId,
        RideDirection direction,
        CancellationToken cancellationToken = default);

    Task<Journey?> GetActiveByDriverProfileIdAsync(
        Guid driverProfileId,
        CancellationToken cancellationToken = default);
}
