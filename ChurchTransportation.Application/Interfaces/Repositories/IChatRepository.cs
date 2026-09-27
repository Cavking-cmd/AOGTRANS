using ChurchTransportation.Domain.Entities;

namespace ChurchTransportation.Application.Interfaces.Repositories;

public interface IChatRepository : IRepository<ChatRoom>
{
    Task<ChatRoom?> GetByJourneyIdAsync(Guid journeyId, CancellationToken cancellationToken = default);

    Task<ChatRoom?> GetGeneralRoomAsync(CancellationToken cancellationToken = default);

    Task<ChatRoom?> GetByIdWithParticipantsAsync(Guid id, CancellationToken cancellationToken = default);

    Task<ChatRoom?> GetByIdWithMessagesAsync(Guid id, CancellationToken cancellationToken = default);
}
