using Ryze.Domain.Entities;

namespace Ryze.Domain.Interfaces.Repositories;

public interface IUserRepository
{
    Task<User?> GetUserByEmailAsync(string email);
    
    Task<User?> GetByIdAsync(Guid userId);
}