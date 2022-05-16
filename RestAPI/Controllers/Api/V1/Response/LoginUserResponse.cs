namespace RestAPI.Controllers.Api.V1.Response;

public class LoginUserResponse
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
}