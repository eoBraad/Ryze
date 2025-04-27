using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ryze.Domain.Entities;
using Ryze.Domain.Enums;

namespace Ryze.Infrastructure.Database.Config;

public class LeadConfiguration : IEntityTypeConfiguration<Lead>
{
    public void Configure(EntityTypeBuilder<Lead> builder)
    {
        builder.ToTable("Leads")
            .HasKey(l => l.Id);

        builder.Property(l => l.LeadValue)
            .HasColumnType("decimal(18,2)");

        builder.Property(l => l.Status)
            .HasDefaultValue(LeadStatus.New);
    }
}