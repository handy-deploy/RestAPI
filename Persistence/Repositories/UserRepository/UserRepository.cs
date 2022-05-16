using Microsoft.EntityFrameworkCore;
using Persistence.Models;
using Persistence.Repositories.UserRepository.Dtos;

namespace Persistence.Repositories.UserRepository;

public class UserRepository : IUserRepository
{
    private readonly IDbContextFactory<HDContext> _factory;

    public UserRepository(IDbContextFactory<HDContext> factory)
    {
        _factory = factory;
    }

    public async Task<User?> Insert(InsertUserDto dto)
    {
        await using var context = await _factory.CreateDbContextAsync();

        var id = Guid.NewGuid();

        var entity = new User
        {
            Id = id,
            Username = dto.Username,
            Password = dto.Password,
            Salt = dto.Salt
        };

        await context.Users.AddAsync(entity);
        await context.SaveChangesAsync();

        var result = await context.Users.FindAsync(id);

        return result;
    }

    public async Task<User?> GetByUsernameAndPassword(string username, string password)
    {
        await using var context = await _factory.CreateDbContextAsync();

        return await context.Users.FirstOrDefaultAsync(x => x.Username.ToLower() == username.ToLower()
                                                            && x.Password.ToLower() == password.ToLower());
    }

    public async Task<User?> GetByUsername(string username)
    {
        await using var context = await _factory.CreateDbContextAsync();

        return await context.Users.FirstOrDefaultAsync(x =>
            x.Username.ToLower() == username.ToLower());
    }
}