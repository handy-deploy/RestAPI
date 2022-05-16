namespace Persistence.Repositories.UserRepository.Dtos;

public class InsertUserDto
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
}