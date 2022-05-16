using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Domain.Extensions;
using Domain.Services.UserService.Dtos;
using Microsoft.IdentityModel.Tokens;
using Persistence.Models;
using Persistence.Repositories;
using Persistence.Repositories.UserRepository.Dtos;

namespace Domain.Services.UserService;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User?> CreateNewUser(CreateNewUserDto dto)
    {
        if (await _userRepository.GetByUsername(dto.Username) != null)
            throw new ArgumentException($"User with username {dto.Username} is already registered.",
                nameof(dto.Username));

        var salt = PasswordSecurityExtension.RandomString(32);

        var saltedPassword = PasswordSecurityExtension.SaltPassword(dto.Password, salt);
        
        var sha = SHA512.Create();
        var shaPassword = await sha.ComputeHashAsync(new MemoryStream(saltedPassword));
        var base64ShaPassword = Convert.ToBase64String(shaPassword);

        return await _userRepository.Insert(new InsertUserDto
        {
            Username = dto.Username,
            Password = base64ShaPassword,
            Salt = salt
        });
    }

    public async Task<ReturnLoginDto> Login(LoginDto dto)
    {
        var user = await _userRepository.GetByUsername(dto.Username);
        
        if (user == null)
            throw new ArgumentException($"Username or password is wrong");

        var saltedPassword = PasswordSecurityExtension.SaltPassword(dto.Password, user.Salt);
        var sha = SHA512.Create();
        var shaPassword = await sha.ComputeHashAsync(new MemoryStream(saltedPassword));
        var base64ShaPassword = Convert.ToBase64String(shaPassword);

        if (await _userRepository.GetByUsernameAndPassword(dto.Username, base64ShaPassword) == null)
            throw new ArgumentException($"Username or password is wrong");
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new("UserId", user.Id.ToString()),
                new("Username", user.Username)
            }),
            Expires = DateTime.UtcNow.AddMinutes(300),
            Audience = "http://localhost"
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return new ReturnLoginDto
        {
            Token = tokenHandler.WriteToken(token)
        };
    }
}