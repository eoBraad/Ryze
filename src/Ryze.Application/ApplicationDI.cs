﻿using Microsoft.Extensions.DependencyInjection;
using Ryze.Application.Services.Login.GetAuthenticatedUser;
using Ryze.Application.Services.Login.LoginUser;
using Ryze.Application.Services.Login.RefreshJwt;
using Ryze.Domain.Interfaces.Generators;

namespace Ryze.Application;

public static class ApplicationDI
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ApplicationDI));
        services.AddScoped<ILoginUserService, LoginUserService>();
        services.AddScoped<IGetAuthenticatedUser, GetAuthenticatedUser>();
        services.AddScoped<IRefreshJwtService, RefreshJwtService>();
    }
}