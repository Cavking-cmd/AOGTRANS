using ChurchTransportation.Application.Interfaces.Repositories;
using ChurchTransportation.Domain.Entities;
using ChurchTransportation.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ChurchTransportation.Infrastructure.Repositories;

public abstract class EfRepository<TEntity> : IRepository<TEntity>
    where TEntity : BaseEntity
{
    private readonly DbSet<TEntity> _set;

    protected EfRepository(ChurchTransportationDbContext context)
    {
        Context = context;
        _set = context.Set<TEntity>();
    }

    protected ChurchTransportationDbContext Context { get; }

    protected IQueryable<TEntity> Query => _set.Where(x => !x.IsDeleted).AsNoTracking();

    protected IQueryable<TEntity> TrackingQuery => _set.Where(x => !x.IsDeleted);

    public virtual async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await Query.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public virtual Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return Query.AnyAsync(x => x.Id == id, cancellationToken);
    }

    public virtual async Task<IReadOnlyList<TEntity>> ListAsync(CancellationToken cancellationToken = default)
    {
        return await Query.ToListAsync(cancellationToken);
    }

    public virtual async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _set.AddAsync(entity, cancellationToken);
    }

    public virtual void Update(TEntity entity)
    {
        _set.Update(entity);
    }

    public virtual void Remove(TEntity entity)
    {
        _set.Remove(entity);
    }
}