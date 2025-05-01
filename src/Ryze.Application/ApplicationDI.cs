using Microsoft.Extensions.DependencyInjection;
using Ryze.Application.Services.User.Login;
using Ryze.Domain.Interfaces.Generators;

namespace Ryze.Application;

public static class ApplicationDI
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ApplicationDI));
        services.AddScoped<ILoginUserService, LoginUserService>();
    }
}