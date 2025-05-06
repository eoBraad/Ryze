using Ryze.Domain.Interfaces.Repositories;

namespace Ryze.Application.Services.User.GetAuthenticatedUser;

public class GetAuthenticatedUser(IUserRepository repository) : IGetAuthenticatedUser
{
    private readonly IUserRepository _userRepository = repository;
    public async Task<Domain.Entities.User?> ExecuteAsync(Guid userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        
        return user;
    }
}