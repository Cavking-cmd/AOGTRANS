using ChurchTransportation.Domain.Enums;
using ChurchTransportation.Domain.Entities;

namespace ChurchTransportation.Application.Interfaces.Repositories;

public interface IRideAssignmentRepository : IRepository<RideAssignment>
{
    Task<RideAssignment?> GetByIdWithJourneyAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<RideAssignment>> GetByRideRequestIdAsync(
        Guid rideRequestId,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<RideAssignment>> GetByJourneyIdAsync(
        Guid journeyId,
        CancellationToken cancellationToken = default);

    Task<RideAssignment?> GetActiveByRideRequestIdAsync(
        Guid rideRequestId,
        CancellationToken cancellationToken = default);
}
