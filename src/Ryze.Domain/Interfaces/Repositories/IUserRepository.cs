using Ryze.Domain.Entities;

namespace Ryze.Domain.Interfaces.Repositories;

public interface IUserRepository
{
    Task<User?> GetUserByEmail(string email);
    
    
}