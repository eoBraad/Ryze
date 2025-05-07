using Ryze.Application.Services.User.GetAuthenticatedUser.Dtos;

namespace Ryze.Application.Services.Login.GetAuthenticatedUser;

public interface IGetAuthenticatedUser
{
    Task<GetAuthenticatedUserDto?> ExecuteAsync(Guid userId);
}