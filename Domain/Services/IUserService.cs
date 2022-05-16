using Domain.Services.UserService.Dtos;
using Persistence.Models;

namespace Domain.Services;

public interface IUserService
{
    Task<User?> CreateNewUser(CreateNewUserDto dto);
    Task<ReturnLoginDto> Login(LoginDto dto);
}