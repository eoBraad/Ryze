using System.Net;
using Ryze.Application.Services.User.Login.Dtos;
using Ryze.Domain.Entities;
using Ryze.Domain.Interfaces.Generators;
using Ryze.Domain.Interfaces.Repositories;
using Ryze.Infrastructure.Exceptions;

namespace Ryze.Application.Services.User.Login;

public class LoginUserService(IUserRepository repository, 
    IPasswordEncripterGenerator passwordEncripterGenerator, 
    IAccessTokenGenerator tokenGenerator,
    IRefreshTokenGenerator refrashTokengenerator, 
    IRefreshTokenRepository refreshTokenRepository) : ILoginUserService
{
    private readonly IUserRepository _userRepository = repository;
    private readonly IPasswordEncripterGenerator _passwordEncripterGenerator = passwordEncripterGenerator;
    private readonly IAccessTokenGenerator _tokenGenerator = tokenGenerator;
    private readonly IRefreshTokenGenerator _refreshTokengenerator = refrashTokengenerator;
    private readonly IRefreshTokenRepository _refreshTokenRepository = refreshTokenRepository;
    
    public async Task<LoginUserResponseDto> LoginUser(LoginUserRequestDto request)
    {
        ValidateRequest(request);
        
        var user = await _userRepository.GetUserByEmailAsync(request.Email);

        if (user == null)
        {
            throw new ValidationException(["User or Password is incorrect"]);
        }
        
        var isPasswordValid = _passwordEncripterGenerator.Verify(request.Password, user.Password);
        
        if (!isPasswordValid)
        {
            throw new ValidationException(["User or Password is incorrect"]);
        }
        
        var token = _tokenGenerator.Generate(user);
        
        var refreshToken = _refreshTokengenerator.Generate();

        var refreshTokenTokenEntity = new RefreshToken()
        {
            IsRevoked = false,
            Token = refreshToken,
            UserId = user.Id,
            ExpirationDate = DateTime.UtcNow.AddDays(1)
        };
        
        await _refreshTokenRepository.AddRefreshTokenAsync(refreshTokenTokenEntity);
        
        return new LoginUserResponseDto()
        {
            Token = token,
            StatusCode = (int)HttpStatusCode.OK,
            RefreshToken = refreshToken
        };
    }
    
    private static void ValidateRequest(LoginUserRequestDto request)
    {
        var validator = new LoginUserValidations();
        
        var result = validator.Validate(request);
        
        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors.Select(x => x.ErrorMessage).ToList());
        }
    }
}