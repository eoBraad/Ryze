namespace Ryze.Domain.Interfaces.Generators;

public interface IPasswordEncripterGenerator
{
    string Encrypt(string password);
    
    bool Verify(string password, string hashedPassword);
}