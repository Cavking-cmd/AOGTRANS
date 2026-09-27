using ChurchTransportation.Application.Common;
using ChurchTransportation.Domain.Entities;
using ChurchTransportation.Domain.Enums;

namespace ChurchTransportation.Application.Interfaces.Services;

public interface IAdminService
{
    Task<IReadOnlyList<SystemSetting>> GetSettingsAsync(string? category, CancellationToken cancellationToken = default);

    Task<OperationResult<SystemSetting>> GetSettingByKeyAsync(string key, CancellationToken cancellationToken = default);

    Task<OperationResult<SystemSetting>> UpsertSettingAsync(
        string key,
        string? value,
        string? category,
        string? description,
        bool isPublic,
        CancellationToken cancellationToken = default);

    Task<OperationResult> DeleteSettingAsync(string key, CancellationToken cancellationToken = default);

    Task<OperationResult> RecordAuditAsync(
        Guid? userId,
        string action,
        string entityType,
        string? entityId,
        string? description,
        string? metadata,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<AuditLog>> GetAuditLogsAsync(
        Guid? userId,
        string? entityType,
        DateTime? from,
        DateTime? to,
        CancellationToken cancellationToken = default);

    Task<OperationResult<Event>> CreateEventAsync(
        string name,
        DateTime startTime,
        DateTime endTime,
        string? locationName,
        CancellationToken cancellationToken = default);

    Task<OperationResult> SetUserRoleAsync(
        Guid userId,
        Guid roleId,
        bool assign,
        CancellationToken cancellationToken = default);
}
