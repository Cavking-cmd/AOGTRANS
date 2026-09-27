using ChurchTransportation.Domain.Entities;

namespace ChurchTransportation.Application.Interfaces.Repositories;

public interface IChatParticipantRepository : IRepository<ChatParticipant>
{
    Task<IReadOnlyList<ChatParticipant>> GetByChatRoomIdAsync(
        Guid chatRoomId,
        CancellationToken cancellationToken = default);

    Task<ChatParticipant?> GetByChatRoomIdAndUserIdAsync(
        Guid chatRoomId,
        Guid userId,
        CancellationToken cancellationToken = default);

    Task<bool> IsParticipantAsync(
        Guid chatRoomId,
        Guid userId,
        CancellationToken cancellationToken = default);
}
