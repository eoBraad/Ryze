using Ryze.Application.Services.User.Login.Dtos;

namespace Ryze.Application.Services.Login.LoginUser;

public interface ILoginUserService
{
    Task<LoginUserResponseDto> LoginUser(LoginUserRequestDto request);
}