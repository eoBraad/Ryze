using Ryze.Domain.Enums;

namespace Ryze.Application.Services.User.GetAuthenticatedUser.Dtos;

public class GetAuthenticatedUserDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public UserGender Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public bool IsActive { get; set; }
    public bool FirstLogin { get; set; }
}