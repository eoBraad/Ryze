using Microsoft.EntityFrameworkCore;
using Ryze.Infrastructure.Exceptions;
using Ryze.Domain.Entities;
using Ryze.Domain.Interfaces.Repositories;
using Ryze.Infrastructure.Database;

namespace Ryze.Infrastructure.Repositories;

public class RefreshTokenRepository(RyzeDbContext context) : IRefreshTokenRepository
{
    private readonly RyzeDbContext _context = context;

    public async Task AddRefreshTokenAsync(RefreshToken refreshToken)
    {
        await _context.RefreshTokens.AddAsync(refreshToken);
    }

    public async Task RevokeRefreshTokenAsync(string token)
    {
        var refreshToken = await _context.RefreshTokens.FirstOrDefaultAsync(t => 
            t.IsRevoked == false && t.Token == token);

        if (refreshToken == null)
            throw new ValidationException(["Refresh token not found"]);

        refreshToken.IsRevoked = true;

        _context.RefreshTokens.Update(refreshToken);
    }
}