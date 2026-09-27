using ChurchTransportation.Application.Common;
using ChurchTransportation.Domain.Entities;
using ChurchTransportation.Domain.Enums;
using ChurchTransportation.Domain.ValueObjects;

namespace ChurchTransportation.Application.Interfaces.Services;

public interface ITrackingService
{
    Task<OperationResult<LocationUpdate>> RecordLocationAsync(
        Guid journeyId,
        GeoCoordinate coordinate,
        decimal? accuracyMeters,
        decimal? speedKph,
        decimal? headingDegrees,
        CancellationToken cancellationToken = default);

    Task<OperationResult<GeoCoordinate>> GetCurrentLocationAsync(
        Guid journeyId,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<LocationUpdate>> GetHistoryAsync(
        Guid journeyId,
        DateTime from,
        DateTime to,
        CancellationToken cancellationToken = default);

    Task<OperationResult<DelayIncident>> ReportDelayAsync(
        Guid journeyId,
        Guid? journeyStopId,
        DelayReason reason,
        string? description,
        CancellationToken cancellationToken = default);

    Task<OperationResult> ResolveDelayAsync(
        Guid delayIncidentId,
        string? description,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<DelayIncident>> GetActiveDelaysAsync(
        Guid journeyId,
        CancellationToken cancellationToken = default);

    Task<OperationResult<Journey>> GetEtaAsync(
        Guid journeyId,
        Guid stopId,
        CancellationToken cancellationToken = default);
}
