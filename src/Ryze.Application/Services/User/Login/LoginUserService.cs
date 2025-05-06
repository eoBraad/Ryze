using System.Net;
using Ryze.Application.Exceptions;
using Ryze.Application.Services.User.Login.Dtos;
using Ryze.Domain.Interfaces.Generators;
using Ryze.Domain.Interfaces.Repositories;

namespace Ryze.Application.Services.User.Login;

public class LoginUserService(IUserRepository repository, IPasswordEncripterGenerator passwordEncripterGenerator, IAccessTokenGenerator tokenGenerator) : ILoginUserService
{
    private readonly IUserRepository _userRepository = repository;
    private readonly IPasswordEncripterGenerator _passwordEncripterGenerator = passwordEncripterGenerator;
    private readonly IAccessTokenGenerator _tokenGenerator = tokenGenerator;
    
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

        return new LoginUserResponseDto()
        {
            Token = token,
            StatusCode = (int)HttpStatusCode.OK
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