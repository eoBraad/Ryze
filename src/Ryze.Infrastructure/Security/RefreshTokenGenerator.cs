using System.Security.Cryptography;
using Ryze.Domain.Interfaces.Generators;

namespace Ryze.Infrastructure.Security;

public class RefreshTokenGenerator : IRefreshTokenGenerator
{
    public string Generate()
    {
        var randomBytes = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomBytes);
        return Convert.ToBase64String(randomBytes);
    }
}