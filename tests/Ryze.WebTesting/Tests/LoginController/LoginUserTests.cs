using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Ryze.Domain.Interfaces.Generators;
using Ryze.Infrastructure.Database;
using Ryze.Infrastructure.Security;
using Ryze.TestUtils.EntityUtils;

namespace Ryze.WebTesting.Tests.LoginController;

public class LoginUserTests : IClassFixture<RyzeTestFactory>
{
    private readonly HttpClient _client;
    private readonly RyzeDbContext _context;
    private readonly IPasswordEncripterGenerator _encripterGenerator;

    public LoginUserTests(RyzeTestFactory factory)
    {
        _client = factory.CreateClient();
        using var scope = factory.Services.CreateScope();
        _context = scope.ServiceProvider.GetRequiredService<RyzeDbContext>();
        _encripterGenerator = scope.ServiceProvider.GetRequiredService<IPasswordEncripterGenerator>();
    }

    [Fact]
    public async Task LoginUser_ValidUser_ReturnsTrue()
    {
        var userAdm = UserEntityUtil.CreateAdminUser();
        
        var userPassword = userAdm.Password;
        
        userAdm.Password = _encripterGenerator.Encrypt(userPassword);
        
        await _context.Users.AddAsync(userAdm);

        await _context.SaveChangesAsync();

        var userCredentials = new { Email = userAdm.Email, Password = userPassword };
        
        var res = await _client.PostAsJsonAsync("api/login", userCredentials);

        var tokens = await _context.RefreshTokens.ToListAsync();

        res.StatusCode.Should().Be(HttpStatusCode.OK);
        tokens.Count.Should().Be(1);

    }
}