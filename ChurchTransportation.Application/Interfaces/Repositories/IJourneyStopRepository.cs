using ChurchTransportation.Domain.Entities;

namespace ChurchTransportation.Application.Interfaces.Repositories;

public interface IJourneyStopRepository : IRepository<JourneyStop>
{
    Task<IReadOnlyList<JourneyStop>> GetByJourneyIdOrderedAsync(
        Guid journeyId,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<JourneyStop>> GetByRideRequestIdAsync(
        Guid rideRequestId,
        CancellationToken cancellationToken = default);

    Task<JourneyStop?> GetNextPendingAsync(
        Guid journeyId,
        CancellationToken cancellationToken = default);

    Task<bool> SequenceNumberExistsAsync(
        Guid journeyId,
        int sequenceNumber,
        CancellationToken cancellationToken = default);
}
