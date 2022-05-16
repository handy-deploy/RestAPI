namespace Domain.Services.UserService.Dtos;

public class ReturnLoginDto
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
}