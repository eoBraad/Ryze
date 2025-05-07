using Ryze.Domain.Entities;

namespace Ryze.Domain.Interfaces.Repositories;

public interface IRefreshTokenRepository
{
    public Task AddRefreshTokenAsync(RefreshToken refreshToken);
    
    public Task RevokeRefreshTokenAsync(string token);
}