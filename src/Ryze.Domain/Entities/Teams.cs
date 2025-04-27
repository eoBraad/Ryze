namespace Ryze.Domain.Entities;

public class Teams : BaseEntity
{
    public string TeamName { get; set; } = string.Empty;

    public string TeamDescription { get; set; } = string.Empty;

    public User TeamLead { get; set; } = new User();

    public List<User> TeamMembers { get; set; } = [];

    public List<Company> Companies { get; set; } = [];
}