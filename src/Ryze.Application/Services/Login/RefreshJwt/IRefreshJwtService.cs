using Ryze.Application.Services.Login.RefreshJwt.Dtos;

namespace Ryze.Application.Services.Login.RefreshJwt;

public interface IRefreshJwtService
{
    Task<RefreshTokenResponseDto> RefreshToken(RefreshTokenRequestDto refreshToken);
}