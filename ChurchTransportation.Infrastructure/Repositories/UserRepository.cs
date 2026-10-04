using ChurchTransportation.Application.Interfaces.Repositories;
using ChurchTransportation.Domain.Entities;
using ChurchTransportation.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ChurchTransportation.Infrastructure.Repositories;

public sealed class UserRepository : EfRepository<User>, IUserRepository
{
    public UserRepository(ChurchTransportationDbContext context)
        : base(context)
    {
    }

    public Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return Query.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
    }

    public Task<bool> EmailExistsAsync(string email, CancellationToken cancellationToken = default)
    {
        return Query.AnyAsync(u => u.Email == email, cancellationToken);
    }

    public Task<User?> GetByIdWithRolesAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return Query
            .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
            .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
    }

    public Task<User?> GetByIdWithProfilesAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return Query
            .Include(u => u.DriverProfile)
            .Include(u => u.PassengerProfile)
            .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
    }

    public async Task AddRoleAsync(UserRole userRole, CancellationToken cancellationToken = default)
    {
        await Context.UserRoles.AddAsync(userRole, cancellationToken);
    }

    public void RemoveRole(UserRole userRole)
    {
        Context.UserRoles.Remove(userRole);
    }
}