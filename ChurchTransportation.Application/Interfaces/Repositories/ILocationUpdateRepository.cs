using ChurchTransportation.Domain.Entities;

namespace ChurchTransportation.Application.Interfaces.Repositories;

public interface ILocationUpdateRepository : IRepository<LocationUpdate>
{
    Task<IReadOnlyList<LocationUpdate>> GetByJourneyIdAsync(
        Guid journeyId,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<LocationUpdate>> GetByJourneyIdSinceAsync(
        Guid journeyId,
        DateTime since,
        CancellationToken cancellationToken = default);

    Task<LocationUpdate?> GetLatestByJourneyIdAsync(
        Guid journeyId,
        CancellationToken cancellationToken = default);

    Task DeleteOlderThanAsync(
        Guid journeyId,
        DateTime cutoff,
        CancellationToken cancellationToken = default);
}
