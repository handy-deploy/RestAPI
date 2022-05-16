using Persistence.Models;
using Persistence.Repositories.UserRepository.Dtos;

namespace Persistence.Repositories;

public interface IUserRepository
{
    Task<User?> Insert(InsertUserDto dto);
    Task<User?> GetByUsernameAndPassword(string username, string password);
    Task<User?> GetByUsername(string username);
}