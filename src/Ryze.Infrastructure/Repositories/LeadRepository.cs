using Microsoft.EntityFrameworkCore;
using Ryze.Domain.Entities;
using Ryze.Domain.Interfaces.Repositories;
using Ryze.Infrastructure.Database;

namespace Ryze.Infrastructure.Repositories;

public class LeadRepository(RyzeDbContext ryzeDbContext, IWorkUnity workUnity) : ILeadRepository
{
    private readonly RyzeDbContext _dbContext = ryzeDbContext;
    private readonly IWorkUnity _workUnity = workUnity;
    
    public async Task<List<Lead>> GetLeadsAsync(int page = 1, int pageSize = 25)
    {
        if (page < 1)
            throw new ArgumentException("Page must be greater than or equal to 1.");
        
        if (pageSize < 1)
            throw new ArgumentException("Page size must be greater than or equal to 1.");
        
        var skip = (page - 1) * pageSize;
        
        var leads = await _dbContext.Leads
            .AsNoTracking()
            .Select(l => new Lead
            {
                Id = l.Id,
                AssignedTo = new User
                {
                    Id = l.AssignedTo.Id,
                    Name = l.AssignedTo.Name,
                },
                CreatedAt = l.CreatedAt,
                Description = l.Description,
                Status = l.Status,
                Products = l.Products.Select(p => new Product
                {
                    Id = p.Id,
                    Name = p.Name,
                }).ToList(),
                LeadOrigin = l.LeadOrigin,
                Company = new Company
                {
                    Id = l.Company.Id,
                    CompanyName = l.Company.CompanyName,
                    CompanyCnpj = l.Company.CompanyCnpj,
                    CompanyPhone = l.Company.CompanyPhone,
                },
                Contact = new Contact
                {
                    FirstName = l.Contact.FirstName,
                    LastName = l.Contact.LastName,
                    Email = l.Contact.Email,
                    Phone = l.Contact.Phone,
                }
            })
            .OrderByDescending(c => c.CreatedAt)
            .Skip(skip)
            .Take(pageSize)
            .ToListAsync();
        
        return leads;
    }

    public async Task<Lead?> GetLeadByIdAsync(Guid id)
    {
        return await _dbContext.Leads
            .AsNoTracking()
            .Select(l => new Lead
            {
                Id = l.Id,
                AssignedTo = new User
                {
                    Id = l.AssignedTo.Id,
                    Name = l.AssignedTo.Name,
                },
                CreatedAt = l.CreatedAt,
                Description = l.Description,
                Status = l.Status,
                Products = l.Products.Select(p => new Product
                {
                    Id = p.Id,
                    Name = p.Name,
                }).ToList(),
                LeadOrigin = l.LeadOrigin,
                Company = new Company
                {
                    Id = l.Company.Id,
                    CompanyName = l.Company.CompanyName,
                    CompanyCnpj = l.Company.CompanyCnpj,
                    CompanyPhone = l.Company.CompanyPhone,
                },
                Contact = new Contact
                {
                    FirstName = l.Contact.FirstName,
                    LastName = l.Contact.LastName,
                    Email = l.Contact.Email,
                    Phone = l.Contact.Phone,
                }
            })
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<Lead>> GetLeadsByUserIdAsync(Guid userId, int page = 1, int pageSize = 10)
    {
        return await _dbContext.Leads
            .AsNoTracking()
            .Select(l => new Lead
            {
                Id = l.Id,
                AssignedTo = new User
                {
                    Id = l.AssignedTo.Id,
                    Name = l.AssignedTo.Name,
                },
                CreatedAt = l.CreatedAt,
                Description = l.Description,
                Status = l.Status,
                Products = l.Products.Select(p => new Product
                {
                    Id = p.Id,
                    Name = p.Name,
                }).ToList(),
                LeadOrigin = l.LeadOrigin,
                Company = new Company
                {
                    Id = l.Company.Id,
                    CompanyName = l.Company.CompanyName,
                    CompanyCnpj = l.Company.CompanyCnpj,
                    CompanyPhone = l.Company.CompanyPhone,
                },
                Contact = new Contact
                {
                    FirstName = l.Contact.FirstName,
                    LastName = l.Contact.LastName,
                    Email = l.Contact.Email,
                    Phone = l.Contact.Phone,
                }
            })
            .Where(c => c.AssignedTo.Id == userId)
            .ToListAsync();
    }

    public async Task CreateAsync(Lead lead)
    {
        _dbContext.Leads.Add(lead);
        await _workUnity.SaveChangesAsync();
    }
}