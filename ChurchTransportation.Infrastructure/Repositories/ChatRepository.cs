using ChurchTransportation.Application.Interfaces.Repositories;
using ChurchTransportation.Domain.Entities;
using ChurchTransportation.Domain.Enums;
using ChurchTransportation.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ChurchTransportation.Infrastructure.Repositories;

public sealed class ChatRepository : EfRepository<ChatRoom>, IChatRepository
{
    public ChatRepository(ChurchTransportationDbContext context)
        : base(context)
    {
    }

    public Task<ChatRoom?> GetByJourneyIdAsync(Guid journeyId, CancellationToken cancellationToken = default)
    {
        return Query
            .Include(c => c.ChatParticipants)
            .Include(c => c.Journey)
            .FirstOrDefaultAsync(c => c.JourneyId == journeyId, cancellationToken);
    }

    public Task<ChatRoom?> GetGeneralRoomAsync(CancellationToken cancellationToken = default)
    {
        return Query
            .Include(c => c.ChatParticipants)
            .FirstOrDefaultAsync(
                c => c.Type == ChatRoomType.General && c.JourneyId == null,
                cancellationToken);
    }

    public Task<ChatRoom?> GetByIdWithParticipantsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return Query
            .Include(c => c.ChatParticipants)
                .ThenInclude(p => p.User)
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }

    public Task<ChatRoom?> GetByIdWithMessagesAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return Query
            .Include(c => c.ChatMessages.OrderByDescending(m => m.SentAt).Take(100))
                .ThenInclude(m => m.Sender)
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }
}