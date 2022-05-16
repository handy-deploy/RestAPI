using Domain.Services;
using Domain.Services.UserService.Dtos;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Controllers.Api.V1.Requests;
using RestAPI.Controllers.Api.V1.Response;

namespace RestAPI.Controllers.Api.V1;

public class UserController : BaseController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPut]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequest request)
    {
        await _userService.CreateNewUser(new CreateNewUserDto
        {
            Username = request.Username,
            Password = request.Password
        });

        return new OkResult();
    }

    [HttpPost]
    public async Task<ActionResult<LoginUserResponse>> LoginUser([FromBody] LoginUserRequest request)
    {
        var result = await _userService.Login(new LoginDto
        {
            Username = request.Username,
            Password = request.Password
        });

        return new OkObjectResult(new LoginUserResponse
        {
            Token = result.Token,
            RefreshToken = result.RefreshToken
        });
    }
}