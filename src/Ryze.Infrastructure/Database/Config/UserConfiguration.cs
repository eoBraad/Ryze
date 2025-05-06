using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ryze.Domain.Entities;
using Ryze.Domain.Enums;

namespace Ryze.Infrastructure.Database.Config;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users")
            .HasKey(u => u.Id);

        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.Password)
            .IsRequired();

        builder.Property(u => u.Role)
            .HasConversion<string>();
        
        builder.HasData(new User
        {
            Id = Guid.Parse("e3f9e4e2-1f34-4d2b-a79f-5c3281a21e9b"), // GUID fixo!
            Name = "ADMIN",
            Email = "admin@admin.com",
            Password = BCrypt.Net.BCrypt.HashPassword("171918Jo@0"), // Em produção, use hash!
            Role = UserRoles.GlobalAdmin,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            Gender = UserGender.Other,
            IsActive = true,
            BirthDate = DateTime.UtcNow.AddYears(-20),
            FirstLogin = false,
            Phone = "(11) 99999-9999"
        });
    }
}