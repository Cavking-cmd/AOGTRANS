using ChurchTransportation.Application.Interfaces.Repositories;
using ChurchTransportation.Domain.Entities;
using ChurchTransportation.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ChurchTransportation.Infrastructure.Repositories;

public sealed class PassengerRepository : EfRepository<PassengerProfile>, IPassengerRepository
{
    public PassengerRepository(ChurchTransportationDbContext context)
        : base(context)
    {
    }

    public Task<PassengerProfile?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return Query
            .Include(p => p.User)
            .FirstOrDefaultAsync(p => p.UserId == userId, cancellationToken);
    }

    public Task<PassengerProfile?> GetByIdWithRideRequestsAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return Query
            .Include(p => p.User)
            .Include(p => p.RideRequests)
                .ThenInclude(r => r.Event)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }
}