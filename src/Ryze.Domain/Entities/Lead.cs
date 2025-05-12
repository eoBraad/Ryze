using Ryze.Domain.Enums;

namespace Ryze.Domain.Entities;

public class Lead : BaseEntity
{
    public Contact Contact { get; set; } = new Contact();
    
    public Company Company { get; set; } = new Company();
    
    public LeadStatus Status { get; set; }

    public User AssignedTo { get; set; } = new User();

    public string Description { get; set; } = string.Empty;
    
    public decimal LeadValue { get; set; }
    
    public LeadOrigin LeadOrigin { get; set; }

    public List<Product> Products { get; set; } = [];
    
}