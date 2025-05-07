using Microsoft.EntityFrameworkCore;
using Ryze.Domain.Entities;
using Ryze.Infrastructure.Database.Config;

namespace Ryze.Infrastructure.Database;

public class RyzeDbContext(DbContextOptions<RyzeDbContext> options) : DbContext(options)
{
    public DbSet<Lead> Leads { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new LeadConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new ContactConfiguration());
        modelBuilder.ApplyConfiguration(new TeamsConfiguration());
        modelBuilder.ApplyConfiguration(new CompanyConfiguration());
    }
}