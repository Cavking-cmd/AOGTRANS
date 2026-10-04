using ChurchTransportation.Application.Interfaces.Repositories;
using ChurchTransportation.Domain.Entities;
using ChurchTransportation.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ChurchTransportation.Infrastructure.Repositories;

public sealed class RoleRepository : EfRepository<Role>, IRoleRepository
{
    public RoleRepository(ChurchTransportationDbContext context)
        : base(context)
    {
    }

    public Task<Role?> GetByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        return Query.FirstOrDefaultAsync(r => r.Name == name, cancellationToken);
    }

    public async Task<IReadOnlyList<Role>> GetSystemRolesAsync(CancellationToken cancellationToken = default)
    {
        return await Query
            .Where(r => r.IsSystemRole)
            .OrderBy(r => r.Name)
            .ToListAsync(cancellationToken);
    }
}