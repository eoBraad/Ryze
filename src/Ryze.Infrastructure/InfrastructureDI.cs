using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ryze.Domain.Interfaces;
using Ryze.Domain.Interfaces.Generators;
using Ryze.Domain.Interfaces.Repositories;
using Ryze.Infrastructure.Database;
using Ryze.Infrastructure.Repositories;
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
        services.AddScoped<IPasswordEncripterGenerator, PasswordEncripter>();
        services.AddScoped<IRefreshTokenGenerator, RefreshTokenGenerator>();
        
        AddRepositories(services);
    }
    
    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IWorkUnity, WorkUnity>();
        services.AddScoped<ILeadRepository, LeadRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
    }
    
    public static void CleanDbContext(this IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<RyzeDbContext>();
        var user = context.Users.FirstOrDefault(u => u.Email == "teste@teste.com");
        if (user == null)
            return;
        
        context.Users.Remove(user);

    }
}