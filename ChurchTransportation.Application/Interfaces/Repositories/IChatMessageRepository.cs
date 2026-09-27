using ChurchTransportation.Application.Common;
using ChurchTransportation.Domain.Entities;

namespace ChurchTransportation.Application.Interfaces.Repositories;

public interface IChatMessageRepository : IRepository<ChatMessage>
{
    Task<PagedResult<ChatMessage>> GetByChatRoomIdAsync(
        Guid chatRoomId,
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<ChatMessage>> GetByChatRoomIdSinceAsync(
        Guid chatRoomId,
        DateTime since,
        CancellationToken cancellationToken = default);
}
