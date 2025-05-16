using Ryze.Domain.Enums;

namespace Ryze.Application.Services.Lead.UserCreateLead.Dto;

public class UserCreateLeadRequestDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Description { get; set; }
    public LeadOrigin LeadOrigin { get; set; }
    public List<Guid> ProductIds { get; set; } = [];
}