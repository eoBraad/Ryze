using Ryze.Application.Services.User.Login.Dtos;

namespace Ryze.Application.Services.User.Login;

public interface ILoginUserService
{
    Task<LoginUserResponseDto> LoginUser(LoginUserRequestDto request);
}