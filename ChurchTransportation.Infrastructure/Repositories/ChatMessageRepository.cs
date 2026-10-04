using ChurchTransportation.Application.Common;
using ChurchTransportation.Application.Interfaces.Repositories;
using ChurchTransportation.Domain.Entities;
using ChurchTransportation.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ChurchTransportation.Infrastructure.Repositories;

public sealed class ChatMessageRepository : EfRepository<ChatMessage>, IChatMessageRepository
{
    public ChatMessageRepository(ChurchTransportationDbContext context)
        : base(context)
    {
    }

    public async Task<PagedResult<ChatMessage>> GetByChatRoomIdAsync(
        Guid chatRoomId,
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken = default)
    {
        var page = Math.Max(1, pageNumber);
        var size = Math.Clamp(pageSize, 1, 200);

        var query = Query.Where(m => m.ChatRoomId == chatRoomId);

        var totalCount = await query.CountAsync(cancellationToken);

        var items = await query
            .OrderByDescending(m => m.SentAt)
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync(cancellationToken);

        return new PagedResult<ChatMessage>(items, page, size, totalCount);
    }

    public async Task<IReadOnlyList<ChatMessage>> GetByChatRoomIdSinceAsync(
        Guid chatRoomId,
        DateTime since,
        CancellationToken cancellationToken = default)
    {
        return await Query
            .Include(m => m.Sender)
            .Where(m => m.ChatRoomId == chatRoomId && m.SentAt >= since)
            .OrderBy(m => m.SentAt)
            .ToListAsync(cancellationToken);
    }
}