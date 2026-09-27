using ChurchTransportation.Application.Common;
using ChurchTransportation.Domain.Entities;
using ChurchTransportation.Domain.Enums;

namespace ChurchTransportation.Application.Interfaces.Services;

public interface IRideAssignmentService
{
    Task<OperationResult<RideAssignment>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<RideAssignment>> GetByRideRequestAsync(
        Guid rideRequestId,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<RideAssignment>> GetByJourneyAsync(
        Guid journeyId,
        CancellationToken cancellationToken = default);

    Task<OperationResult<RideAssignment>> AssignAsync(
        Guid rideRequestId,
        Guid journeyId,
        string? assignmentReason,
        decimal? matchingScore,
        Guid? assignedByUserId,
        CancellationToken cancellationToken = default);

    Task<OperationResult> AcceptAsync(Guid id, CancellationToken cancellationToken = default);

    Task<OperationResult> ReassignAsync(
        Guid id,
        Guid newJourneyId,
        string? reassignmentReason,
        CancellationToken cancellationToken = default);

    Task<OperationResult> CancelAsync(
        Guid id,
        string? reason,
        CancellationToken cancellationToken = default);
}
