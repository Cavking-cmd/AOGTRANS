using ChurchTransportation.Application.Common;
using ChurchTransportation.Domain.Entities;
using ChurchTransportation.Domain.Enums;

namespace ChurchTransportation.Application.Interfaces.External;

public interface INotificationSender
{
    Task<OperationResult> SendAsync(
        Guid userId,
        NotificationType type,
        string title,
        string message,
        IReadOnlyDictionary<string, string>? metadata = null,
        CancellationToken cancellationToken = default);

    Task<OperationResult> SendBulkAsync(
        IReadOnlyCollection<Guid> userIds,
        NotificationType type,
        string title,
        string message,
        CancellationToken cancellationToken = default);
}
