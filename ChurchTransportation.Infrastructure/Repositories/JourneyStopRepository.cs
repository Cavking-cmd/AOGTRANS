using ChurchTransportation.Application.Interfaces.Repositories;
using ChurchTransportation.Domain.Entities;
using ChurchTransportation.Domain.Enums;
using ChurchTransportation.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ChurchTransportation.Infrastructure.Repositories;

public sealed class JourneyStopRepository : EfRepository<JourneyStop>, IJourneyStopRepository
{
    public JourneyStopRepository(ChurchTransportationDbContext context)
        : base(context)
    {
    }

    public async Task<IReadOnlyList<JourneyStop>> GetByJourneyIdOrderedAsync(
        Guid journeyId,
        CancellationToken cancellationToken = default)
    {
        return await Query
            .Include(s => s.RideRequest)
                .ThenInclude(r => r!.PassengerProfile)
            .Where(s => s.JourneyId == journeyId)
            .OrderBy(s => s.SequenceNumber)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<JourneyStop>> GetByRideRequestIdAsync(
        Guid rideRequestId,
        CancellationToken cancellationToken = default)
    {
        return await Query
            .Include(s => s.Journey)
            .Where(s => s.RideRequestId == rideRequestId)
            .OrderBy(s => s.JourneyId)
            .ThenBy(s => s.SequenceNumber)
            .ToListAsync(cancellationToken);
    }

    public Task<JourneyStop?> GetNextPendingAsync(Guid journeyId, CancellationToken cancellationToken = default)
    {
        return Query
            .Where(s => s.JourneyId == journeyId && s.Status == JourneyStopStatus.Pending)
            .OrderBy(s => s.SequenceNumber)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public Task<bool> SequenceNumberExistsAsync(
        Guid journeyId,
        int sequenceNumber,
        CancellationToken cancellationToken = default)
    {
        return Query.AnyAsync(
            s => s.JourneyId == journeyId && s.SequenceNumber == sequenceNumber,
            cancellationToken);
    }
}