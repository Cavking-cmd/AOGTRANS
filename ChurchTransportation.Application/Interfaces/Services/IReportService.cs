using ChurchTransportation.Application.Common;
using ChurchTransportation.Domain.Enums;

namespace ChurchTransportation.Application.Interfaces.Services;

public interface IReportService
{
    Task<OperationResult<JourneyReportSummary>> GetJourneySummaryAsync(
        Guid eventId,
        CancellationToken cancellationToken = default);

    Task<OperationResult<DriverPerformanceReport>> GetDriverPerformanceAsync(
        Guid driverProfileId,
        DateTime from,
        DateTime to,
        CancellationToken cancellationToken = default);

    Task<OperationResult<VehicleUtilisationReport>> GetVehicleUtilisationAsync(
        Guid vehicleId,
        DateTime from,
        DateTime to,
        CancellationToken cancellationToken = default);

    Task<OperationResult<DelayReport>> GetDelayReportAsync(
        Guid eventId,
        DateTime from,
        DateTime to,
        CancellationToken cancellationToken = default);

    Task<OperationResult<RideDemandReport>> GetRideDemandAsync(
        Guid eventId,
        RideDirection direction,
        CancellationToken cancellationToken = default);
}

public sealed record JourneyReportSummary(
    Guid EventId,
    int TotalJourneys,
    int TotalStops,
    int PassengersTransported,
    int CompletedJourneys,
    int CancelledJourneys);

public sealed record DriverPerformanceReport(
    Guid DriverProfileId,
    int TotalJourneys,
    int TotalPassengers,
    decimal TotalDistanceKm,
    decimal TotalDelayMinutes,
    int CompletedJourneys);

public sealed record VehicleUtilisationReport(
    Guid VehicleId,
    int TotalJourneys,
    decimal TotalDistanceKm,
    decimal? AverageOccupancyPercentage);

public sealed record DelayReport(
    Guid EventId,
    int TotalDelayIncidents,
    decimal TotalDelayMinutes,
    decimal AverageDelayMinutes,
    IReadOnlyDictionary<DelayReason, int> IncidentsByReason);

public sealed record RideDemandReport(
    Guid EventId,
    RideDirection Direction,
    int TotalRequests,
    int AssignedRequests,
    int CancelledRequests,
    int NoShowRequests);
