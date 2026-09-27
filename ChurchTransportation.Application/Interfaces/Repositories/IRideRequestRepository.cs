using ChurchTransportation.Domain.Enums;
using ChurchTransportation.Domain.Entities;

namespace ChurchTransportation.Application.Interfaces.Repositories;

public interface IRideRequestRepository : IRepository<RideRequest>
{
    Task<RideRequest?> GetByIdWithAssignmentAsync(Guid id, CancellationToken cancellationToken = default);

    Task<RideRequest?> GetByIdWithJourneyStopsAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<RideRequest>> GetByEventIdAsync(
        Guid eventId,
        RideDirection direction,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<RideRequest>> GetByPassengerProfileIdAsync(
        Guid passengerProfileId,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<RideRequest>> GetByStatusForEventAsync(
        Guid eventId,
        RideRequestStatus status,
        CancellationToken cancellationToken = default);
}
