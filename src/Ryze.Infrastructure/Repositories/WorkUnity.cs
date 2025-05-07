using Ryze.Domain.Interfaces.Repositories;
using Ryze.Infrastructure.Database;

namespace Ryze.Infrastructure.Repositories;

public class WorkUnity(RyzeDbContext dbContext) : IWorkUnity
{
    private readonly RyzeDbContext _dbContext = dbContext;
    
    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();    
    }
}