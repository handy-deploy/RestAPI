using System.Text;

namespace Domain.Extensions;

public static class PasswordSecurityExtension
{
    private static readonly Random Random = new();

    public static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_+<>,.:;|{}[]-=+";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[Random.Next(s.Length)]).ToArray());
    }

    public static byte[] SaltPassword(string password, string salt)
    {
        var saltedPasswordString = $"{salt.Substring(0, 16)}{password}{salt.Substring(16, 16)}";

        return Encoding.UTF8.GetBytes(saltedPasswordString);
    }
}