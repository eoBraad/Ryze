using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Ryze.Domain.Entities;
using Ryze.Domain.Interfaces;

namespace Ryze.Infrastructure.Security;

public class JwtTokenGenerator(uint tokenExpirationInMinutes, string secretKey) : IAccessTokenGenerator
{
    private readonly uint _tokenExpirationInMinutes = tokenExpirationInMinutes;
    private readonly string _secretKey = secretKey;


    public string Generate(User user)
    {
        var claims = new[]
        {
            new Claim("id", user.Id.ToString()),
            new Claim("role", user.Role.ToString())
        };
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(_tokenExpirationInMinutes),
            SigningCredentials = new SigningCredentials(GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256Signature)
        };
        
        var tokenHandler = new JwtSecurityTokenHandler();

        var securityToken = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(securityToken);
    }
    
    private SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
    }

}