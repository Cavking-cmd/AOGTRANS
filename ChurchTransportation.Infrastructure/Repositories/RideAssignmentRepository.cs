using ChurchTransportation.Application.Interfaces.Repositories;
using ChurchTransportation.Domain.Entities;
using ChurchTransportation.Domain.Enums;
using ChurchTransportation.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ChurchTransportation.Infrastructure.Repositories;

public sealed class RideAssignmentRepository : EfRepository<RideAssignment>, IRideAssignmentRepository
{
    public RideAssignmentRepository(ChurchTransportationDbContext context)
        : base(context)
    {
    }

    public Task<RideAssignment?> GetByIdWithJourneyAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return Query
            .Include(a => a.Journey)
            .Include(a => a.RideRequest)
            .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<RideAssignment>> GetByRideRequestIdAsync(
        Guid rideRequestId,
        CancellationToken cancellationToken = default)
    {
        return await Query
            .Include(a => a.Journey)
            .Where(a => a.RideRequestId == rideRequestId)
            .OrderByDescending(a => a.AssignedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<RideAssignment>> GetByJourneyIdAsync(
        Guid journeyId,
        CancellationToken cancellationToken = default)
    {
        return await Query
            .Include(a => a.RideRequest)
            .Where(a => a.JourneyId == journeyId)
            .OrderBy(a => a.AssignedAt)
            .ToListAsync(cancellationToken);
    }

    public Task<RideAssignment?> GetActiveByRideRequestIdAsync(
        Guid rideRequestId,
        CancellationToken cancellationToken = default)
    {
        return Query
            .Include(a => a.Journey)
            .FirstOrDefaultAsync(a =>
                a.RideRequestId == rideRequestId &&
                (a.Status == RideAssignmentStatus.Proposed ||
                 a.Status == RideAssignmentStatus.Assigned ||
                 a.Status == RideAssignmentStatus.Accepted),
                cancellationToken);
    }
}