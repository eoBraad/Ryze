using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Ryze.Domain.Entities;
using Ryze.Domain.Enums;
using Ryze.Infrastructure.Database;

namespace Ryze.WebTesting;

public class RyzeTestFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("test").ConfigureServices(services =>
        {
            // Remove o banco real
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(DbContextOptions<RyzeDbContext>));
            if (descriptor != null)
                services.Remove(descriptor);

            // Adiciona o banco InMemory
            services.AddDbContext<RyzeDbContext>(options =>
            {
                options.UseInMemoryDatabase("RyzeCRMTestDb");
            });
           
        });
    }
}