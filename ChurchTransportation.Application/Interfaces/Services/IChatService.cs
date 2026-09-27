using ChurchTransportation.Application.Common;
using ChurchTransportation.Domain.Entities;
using ChurchTransportation.Domain.Enums;

namespace ChurchTransportation.Application.Interfaces.Services;

public interface IChatService
{
    Task<OperationResult<ChatRoom>> GetRoomByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<OperationResult<ChatRoom>> GetOrCreateGeneralRoomAsync(CancellationToken cancellationToken = default);

    Task<OperationResult<ChatRoom>> GetOrCreateJourneyRoomAsync(
        Guid journeyId,
        CancellationToken cancellationToken = default);

    Task<OperationResult> AddParticipantAsync(
        Guid chatRoomId,
        Guid userId,
        CancellationToken cancellationToken = default);

    Task<OperationResult> RemoveParticipantAsync(
        Guid chatRoomId,
        Guid userId,
        CancellationToken cancellationToken = default);

    Task<OperationResult<ChatMessage>> SendMessageAsync(
        Guid chatRoomId,
        Guid senderUserId,
        string content,
        CancellationToken cancellationToken = default);

    Task<PagedResult<ChatMessage>> GetMessagesAsync(
        Guid chatRoomId,
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken = default);

    Task<OperationResult> CloseRoomAsync(Guid chatRoomId, CancellationToken cancellationToken = default);
}
