using ChurchTransportation.Application.Common;
using ChurchTransportation.Domain.Entities;
using ChurchTransportation.Domain.Enums;

namespace ChurchTransportation.Application.Interfaces.Services;

public interface IEventService
{
    Task<OperationResult<Event>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Event>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Event>> GetByStatusAsync(EventStatus status, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Event>> GetUpcomingAsync(int daysAhead, CancellationToken cancellationToken = default);

    Task<OperationResult<Event>> CreateAsync(
        string name,
        string? description,
        string? locationName,
        string? address,
        decimal? latitude,
        decimal? longitude,
        DateTime startTime,
        DateTime endTime,
        CancellationToken cancellationToken = default);

    Task<OperationResult> UpdateAsync(
        Guid id,
        string name,
        string? description,
        string? locationName,
        string? address,
        decimal? latitude,
        decimal? longitude,
        DateTime startTime,
        DateTime endTime,
        CancellationToken cancellationToken = default);

    Task<OperationResult> SetStatusAsync(
        Guid id,
        EventStatus status,
        CancellationToken cancellationToken = default);
}
