using Microsoft.EntityFrameworkCore;
using Ryze.Domain.Entities;
using Ryze.Domain.Interfaces.Repositories;
using Ryze.Infrastructure.Database;

namespace Ryze.Infrastructure.Repositories;

public class ProductRepository(RyzeDbContext dbContext) : IProductRepository
{
    private readonly RyzeDbContext _context = dbContext;
    public async Task<List<Product>> GetProductsWithListIdsAsync(List<Guid> productIds)
    {
        return await _context.Products.Where(p => productIds.Contains(p.Id)).ToListAsync();
    }
}