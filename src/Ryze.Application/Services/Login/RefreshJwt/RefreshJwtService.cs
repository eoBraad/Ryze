using Microsoft.Identity.Client;
using Ryze.Application.Services.Login.RefreshJwt.Dtos;
using Ryze.Domain.Entities;
using Ryze.Domain.Interfaces.Generators;
using Ryze.Domain.Interfaces.Repositories;
using Ryze.Infrastructure.Exceptions;

namespace Ryze.Application.Services.Login.RefreshJwt;

public class RefreshJwtService(IAccessTokenGenerator accessTokenGenerator, 
    IRefreshTokenGenerator refreshTokenGenerator, 
    IRefreshTokenRepository refreshTokenRepository, IUserRepository userRepository)
{
    private readonly IAccessTokenGenerator _accessTokenGenerator = accessTokenGenerator;
    private readonly IRefreshTokenGenerator _refreshTokenGenerator = refreshTokenGenerator;
    private readonly IRefreshTokenRepository _refreshTokenRepository = refreshTokenRepository;
    private readonly IUserRepository _userRepository = userRepository;
    
    public async Task<RefreshTokenResponseDto> RefreshToken(RefreshTokenRequestDto refreshToken)
    {
        ValidateRequest(refreshToken);
        
        await _refreshTokenRepository.RevokeRefreshTokenAsync(refreshToken.RefreshToken);
        
        var refreshTokenEntity = await _refreshTokenRepository.GetRefreshTokenAsync(refreshToken.RefreshToken);
        
        var user = await _userRepository.GetByIdAsync(refreshTokenEntity!.UserId);
        
        var newRefreshToken = _refreshTokenGenerator.Generate();

        await _refreshTokenRepository.AddRefreshTokenAsync(new RefreshToken()
        {
            ExpirationDate = DateTime.UtcNow.AddDays(1),
            IsRevoked = false,
            Token = newRefreshToken,
            UserId = user!.Id
        });
        
        var newAccessToken = _accessTokenGenerator.Generate(user);

        return new RefreshTokenResponseDto()
        {
            RefreshToken = newRefreshToken,
            AccessToken = newAccessToken
        };
    }
    
    private static void ValidateRequest(RefreshTokenRequestDto request)
    {
        var validator = new RefreshJwtValidator();
        var validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
        }
        
    }
}