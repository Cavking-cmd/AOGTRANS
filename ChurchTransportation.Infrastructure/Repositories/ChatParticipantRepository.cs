using ChurchTransportation.Application.Interfaces.Repositories;
using ChurchTransportation.Domain.Entities;
using ChurchTransportation.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ChurchTransportation.Infrastructure.Repositories;

public sealed class ChatParticipantRepository : EfRepository<ChatParticipant>, IChatParticipantRepository
{
    public ChatParticipantRepository(ChurchTransportationDbContext context)
        : base(context)
    {
    }

    public async Task<IReadOnlyList<ChatParticipant>> GetByChatRoomIdAsync(
        Guid chatRoomId,
        CancellationToken cancellationToken = default)
    {
        return await Query
            .Include(p => p.User)
            .Where(p => p.ChatRoomId == chatRoomId && p.LeftAt == null)
            .OrderBy(p => p.JoinedAt)
            .ToListAsync(cancellationToken);
    }

    public Task<ChatParticipant?> GetByChatRoomIdAndUserIdAsync(
        Guid chatRoomId,
        Guid userId,
        CancellationToken cancellationToken = default)
    {
        return Query
            .Include(p => p.User)
            .FirstOrDefaultAsync(p => p.ChatRoomId == chatRoomId && p.UserId == userId, cancellationToken);
    }

    public Task<bool> IsParticipantAsync(
        Guid chatRoomId,
        Guid userId,
        CancellationToken cancellationToken = default)
    {
        return Query.AnyAsync(
            p => p.ChatRoomId == chatRoomId && p.UserId == userId && p.LeftAt == null,
            cancellationToken);
    }
}