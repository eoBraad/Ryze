using Ryze.Domain.Entities;

namespace Ryze.Domain.Interfaces.Repositories;

public interface ILeadRepository
{
    Task<List<Lead>> GetLeadsAsync(int page = 1, int pageSize = 10);
    Task<Lead?> GetLeadByIdAsync(Guid id);
    Task<List<Lead>> GetLeadsByUserIdAsync(Guid userId, int page = 1, int pageSize = 10);
    Task CreateAsync(Lead lead);
}