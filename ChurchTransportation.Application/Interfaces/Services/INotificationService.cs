using ChurchTransportation.Application.Common;
using ChurchTransportation.Domain.Entities;
using ChurchTransportation.Domain.Enums;

namespace ChurchTransportation.Application.Interfaces.Services;

public interface INotificationService
{
    Task<IReadOnlyList<Notification>> GetForUserAsync(
        Guid userId,
        bool unreadOnly,
        CancellationToken cancellationToken = default);

    Task<int> GetUnreadCountAsync(Guid userId, CancellationToken cancellationToken = default);

    Task<OperationResult> MarkAsReadAsync(Guid notificationId, Guid userId, CancellationToken cancellationToken = default);

    Task<OperationResult> MarkAllAsReadAsync(Guid userId, CancellationToken cancellationToken = default);

    Task<OperationResult> SendAsync(
        Guid userId,
        NotificationType type,
        string title,
        string message,
        Guid? rideRequestId,
        Guid? journeyId,
        CancellationToken cancellationToken = default);
}
