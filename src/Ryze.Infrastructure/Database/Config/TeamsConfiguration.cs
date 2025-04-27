using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ryze.Domain.Entities;

namespace Ryze.Infrastructure.Database.Config;

public class TeamsConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.ToTable("Teams")
            .HasKey(t => t.Id);
    }
}