using ChurchTransportation.Application.Interfaces.Repositories;
using ChurchTransportation.Domain.Entities;
using ChurchTransportation.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ChurchTransportation.Infrastructure.Repositories;

public sealed class LocationUpdateRepository : EfRepository<LocationUpdate>, ILocationUpdateRepository
{
    public LocationUpdateRepository(ChurchTransportationDbContext context)
        : base(context)
    {
    }

    public async Task<IReadOnlyList<LocationUpdate>> GetByJourneyIdAsync(
        Guid journeyId,
        CancellationToken cancellationToken = default)
    {
        return await Query
            .Where(l => l.JourneyId == journeyId)
            .OrderBy(l => l.Timestamp)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<LocationUpdate>> GetByJourneyIdSinceAsync(
        Guid journeyId,
        DateTime since,
        CancellationToken cancellationToken = default)
    {
        return await Query
            .Where(l => l.JourneyId == journeyId && l.Timestamp >= since)
            .OrderBy(l => l.Timestamp)
            .ToListAsync(cancellationToken);
    }

    public Task<LocationUpdate?> GetLatestByJourneyIdAsync(
        Guid journeyId,
        CancellationToken cancellationToken = default)
    {
        return Query
            .Where(l => l.JourneyId == journeyId)
            .OrderByDescending(l => l.Timestamp)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task DeleteOlderThanAsync(
        Guid journeyId,
        DateTime cutoff,
        CancellationToken cancellationToken = default)
    {
        var stale = await TrackingQuery
            .Where(l => l.JourneyId == journeyId && l.Timestamp < cutoff)
            .ToListAsync(cancellationToken);

        Context.LocationUpdates.RemoveRange(stale);
    }
}