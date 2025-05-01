using Ryze.Domain.Interfaces.Generators;
using BC = BCrypt.Net.BCrypt;

namespace Ryze.Infrastructure.Security;

public class PasswordEncripter : IPasswordEncripterGenerator
{
    public string Encrypt(string password)
    {
        return BC.HashPassword(password);
    }

    public bool Verify(string password, string encryptedPassword)
    {
        return BC.Verify(password, encryptedPassword);
    }
}