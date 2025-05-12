using Ryze.Application.Services.User.CreateUser.Dtos;

namespace Ryze.Application.Services.User.CreateUser;

public interface ICreateUserService
{
    Task<Guid> CreateUserAsync(CreateUserRequestDto request);
}