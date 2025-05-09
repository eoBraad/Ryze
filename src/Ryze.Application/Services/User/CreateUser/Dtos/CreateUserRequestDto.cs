using Ryze.Domain.Enums;

namespace Ryze.Application.Services.User.CreateUser.Dtos;

public class CreateUserRequestDto
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public UserGender Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public UserRoles Role { get; set; }
}