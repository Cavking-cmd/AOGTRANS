using ChurchTransportation.Domain.Entities;
using ChurchTransportation.Domain.Enums;
using ChurchTransportation.Infrastructure.Persistence;
using ChurchTransportation.Infrastructure.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace ChurchTransportation.Tests.Integration;

public sealed class RepositoryIntegrationTests : IDisposable
{
    private readonly SqliteConnection _connection;
    private readonly ChurchTransportationDbContext _context;

    public RepositoryIntegrationTests()
    {
        _connection = new SqliteConnection("DataSource=:memory:");
        _connection.Open();

        var options = new DbContextOptionsBuilder<ChurchTransportationDbContext>()
            .UseSqlite(_connection)
            .Options;

        _context = new ChurchTransportationDbContext(options);
        _context.Database.EnsureCreated();
    }

    [Fact]
    public async Task Add_ThenGetById_ReturnsPersistedEntity()
    {
        var repository = new UserRepository(_context);
        var unitOfWork = new EfUnitOfWork(_context);
        var user = new User
        {
            Email = "john@example.com",
            FirstName = "John",
            LastName = "Doe",
            Status = UserStatus.Active
        };

        await repository.AddAsync(user);
        var affected = await unitOfWork.SaveChangesAsync();

        affected.ShouldBe(1);
        user.Id.ShouldNotBe(Guid.Empty);

        var loaded = await repository.GetByIdAsync(user.Id);

        loaded.ShouldNotBeNull();
        loaded!.Email.ShouldBe("john@example.com");
        loaded.CreatedDate.ShouldNotBe(default);
    }

    [Fact]
    public async Task GetByEmailAndEmailExists_FindUser()
    {
        var repository = new UserRepository(_context);
        await SeedUserAsync("mary@example.com");

        var byEmail = await repository.GetByEmailAsync("mary@example.com");
        var exists = await repository.EmailExistsAsync("mary@example.com");
        var missing = await repository.GetByEmailAsync("nobody@example.com");

        byEmail.ShouldNotBeNull();
        exists.ShouldBeTrue();
        missing.ShouldBeNull();
    }

    [Fact]
    public async Task ExistsAsync_ReturnsFalseForUnknownId()
    {
        var repository = new UserRepository(_context);

        (await repository.ExistsAsync(Guid.NewGuid())).ShouldBeFalse();
    }

    [Fact]
    public async Task ListAsync_ExcludesSoftDeletedEntities()
    {
        var repository = new UserRepository(_context);
        var kept = await SeedUserAsync("kept@example.com");
        var deleted = await SeedUserAsync("deleted@example.com");

        deleted.IsDeleted = true;
        repository.Update(deleted);
        await new EfUnitOfWork(_context).SaveChangesAsync();

        var users = await repository.ListAsync();

        users.Select(u => u.Id).ShouldContain(kept.Id);
        users.Select(u => u.Id).ShouldNotContain(deleted.Id);
    }

    [Fact]
    public async Task GetByIdWithRolesAsync_IncludesAssignedRole()
    {
        var repository = new UserRepository(_context);
        var roleRepository = new RoleRepository(_context);
        var unitOfWork = new EfUnitOfWork(_context);

        var user = new User
        {
            Email = "roles@example.com",
            FirstName = "Role",
            LastName = "Holder"
        };

        var role = new Role { Name = "Driver" };

        await repository.AddAsync(user);
        await roleRepository.AddAsync(role);
        await unitOfWork.SaveChangesAsync();

        await repository.AddRoleAsync(new UserRole
        {
            User = user,
            Role = role,
            UserId = user.Id,
            RoleId = role.Id
        });

        await unitOfWork.SaveChangesAsync();

        var loaded = await repository.GetByIdWithRolesAsync(user.Id);

        loaded.ShouldNotBeNull();
        loaded!.UserRoles.Count.ShouldBe(1);
        loaded.UserRoles.First().Role.Name.ShouldBe("Driver");
    }

    [Fact]
    public async Task RemoveRole_RemovesAssignment()
    {
        var repository = new UserRepository(_context);
        var roleRepository = new RoleRepository(_context);
        var unitOfWork = new EfUnitOfWork(_context);

        var user = new User { Email = "remove@example.com", FirstName = "Rem", LastName = "Ove" };
        var role = new Role { Name = "Admin" };

        await repository.AddAsync(user);
        await roleRepository.AddAsync(role);
        await unitOfWork.SaveChangesAsync();

        var userRole = new UserRole { User = user, Role = role };
        userRole.UserId = user.Id;
        userRole.RoleId = role.Id;
        await repository.AddRoleAsync(userRole);
        await unitOfWork.SaveChangesAsync();

        repository.RemoveRole(userRole);
        await unitOfWork.SaveChangesAsync();

        var loaded = await repository.GetByIdWithRolesAsync(user.Id);

        loaded!.UserRoles.ShouldBeEmpty();
    }

    [Fact]
    public async Task UnitOfWork_RollsBackTransaction()
    {
        var repository = new RoleRepository(_context);
        var unitOfWork = new EfUnitOfWork(_context);
        var role = new Role { Name = "Passenger" };

        await unitOfWork.BeginTransactionAsync();
        await repository.AddAsync(role);
        await unitOfWork.SaveChangesAsync();
        await unitOfWork.RollbackTransactionAsync();

        (await repository.GetByNameAsync("Passenger")).ShouldBeNull();
    }

    public void Dispose()
    {
        _context.Dispose();
        _connection.Dispose();
    }

    private async Task<User> SeedUserAsync(string email)
    {
        var repository = new UserRepository(_context);
        var user = new User
        {
            Email = email,
            FirstName = "Test",
            LastName = "User"
        };

        await repository.AddAsync(user);
        await new EfUnitOfWork(_context).SaveChangesAsync();

        return user;
    }
}