using ChurchTransportation.Application.Common;
using ChurchTransportation.Domain.Entities;
using ChurchTransportation.Domain.Enums;

namespace ChurchTransportation.Application.Interfaces.Services;

public interface IJourneyStopService
{
    Task<OperationResult<JourneyStop>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<JourneyStop>> GetByJourneyAsync(Guid journeyId, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<JourneyStop>> GetByRideRequestAsync(
        Guid rideRequestId,
        CancellationToken cancellationToken = default);

    Task<OperationResult<JourneyStop>> AddAsync(
        Guid journeyId,
        Guid? rideRequestId,
        JourneyStopType stopType,
        string address,
        decimal latitude,
        decimal longitude,
        DateTime? plannedArrivalTime,
        string? notes,
        CancellationToken cancellationToken = default);

    Task<OperationResult> UpdateAsync(
        Guid id,
        string address,
        decimal latitude,
        decimal longitude,
        DateTime? plannedArrivalTime,
        string? notes,
        CancellationToken cancellationToken = default);

    Task<OperationResult> ReorderAsync(
        Guid journeyId,
        IReadOnlyList<Guid> orderedStopIds,
        CancellationToken cancellationToken = default);

    Task<OperationResult> RemoveAsync(Guid id, CancellationToken cancellationToken = default);

    Task<OperationResult> MarkArrivedAsync(Guid id, CancellationToken cancellationToken = default);

    Task<OperationResult> MarkPickupAsync(Guid id, CancellationToken cancellationToken = default);

    Task<OperationResult> MarkDropOffAsync(Guid id, CancellationToken cancellationToken = default);

    Task<OperationResult> SetStatusAsync(
        Guid id,
        JourneyStopStatus status,
        CancellationToken cancellationToken = default);
}
