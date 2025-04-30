using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ryze.Domain.Entities;
using Ryze.Domain.Interfaces;
using Ryze.Infrastructure.Database;
using Ryze.Infrastructure.Security;

namespace Ryze.Infrastructure;

public static class InfrastructureDi
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var signKey = configuration.GetSection("Jwt:Key").Value;
        var expirationInMinutes = uint.Parse(configuration.GetSection("Jwt:ExpiresInMinutes").Value!);
        
        services.AddDbContext<RyzeDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IAccessTokenGenerator>(c => new JwtTokenGenerator(expirationInMinutes, signKey!));
    }
}