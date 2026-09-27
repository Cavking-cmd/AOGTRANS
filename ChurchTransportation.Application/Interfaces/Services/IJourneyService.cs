using ChurchTransportation.Application.Common;
using ChurchTransportation.Domain.Entities;
using ChurchTransportation.Domain.Enums;

namespace ChurchTransportation.Application.Interfaces.Services;

public interface IJourneyService
{
    Task<OperationResult<Journey>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Journey>> GetByDriverAsync(Guid driverProfileId, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Journey>> GetByEventAsync(
        Guid eventId,
        RideDirection direction,
        CancellationToken cancellationToken = default);

    Task<OperationResult<Journey>> CreateAsync(
        Guid eventId,
        Guid driverProfileId,
        Guid vehicleId,
        RideDirection direction,
        DateTime? plannedStartTime,
        DateTime? plannedEndTime,
        string? notes,
        CancellationToken cancellationToken = default);

    Task<OperationResult> UpdateAsync(
        Guid id,
        Guid vehicleId,
        DateTime? plannedStartTime,
        DateTime? plannedEndTime,
        string? notes,
        CancellationToken cancellationToken = default);

    Task<OperationResult> SetStatusAsync(
        Guid id,
        JourneyStatus status,
        CancellationToken cancellationToken = default);

    Task<OperationResult<Journey>> StartAsync(Guid id, CancellationToken cancellationToken = default);

    Task<OperationResult<Journey>> CompleteAsync(Guid id, CancellationToken cancellationToken = default);

    Task<OperationResult<Journey>> CancelAsync(Guid id, string? reason, CancellationToken cancellationToken = default);

    Task<OperationResult<Journey>> GetByReferenceCodeAsync(
        string referenceCode,
        CancellationToken cancellationToken = default);
}
