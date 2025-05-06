using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Ryze.Application;
using Ryze.Domain.Entities;
using Ryze.Domain.Enums;
using Ryze.Infrastructure;
using Ryze.Infrastructure.Database;
using Ryze.Web.Filter;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(c =>
{
    c.Filters.Add<RyzeExceptionFilter>();
});

builder.Services.AddRouting(r => r.LowercaseUrls = true);

builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplicationServices();

var key = builder.Configuration.GetSection("Jwt:Key").Value;

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key!))
        };
    });

builder.Services.AddAuthorizationBuilder()
    .AddPolicy(nameof(UserRoles.GlobalAdmin), policy => policy.RequireRole(nameof(UserRoles.GlobalAdmin)))
    .AddPolicy(nameof(UserRoles.Manager), policy => policy.RequireRole(nameof(UserRoles.GlobalAdmin)))
    .AddPolicy(nameof(UserRoles.Seller), policy => policy.RequireRole(nameof(UserRoles.GlobalAdmin)));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowAll");

app.MapControllers();

app.Run();