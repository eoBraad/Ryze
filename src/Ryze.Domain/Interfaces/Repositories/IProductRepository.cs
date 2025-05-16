using Ryze.Domain.Entities;

namespace Ryze.Domain.Interfaces.Repositories;

public interface IProductRepository
{
    Task<List<Product>> GetProductsWithListIdsAsync(List<Guid> productIds);
}