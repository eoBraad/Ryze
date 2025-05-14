using Ryze.Domain.Enums;

namespace Ryze.Domain.Entities;

public class Lead : BaseEntity
{
    public Contact Contact { get; set; } 
    
    public Company Company { get; set; } 
    
    public LeadStatus Status { get; set; } = LeadStatus.New;

    public User AssignedTo { get; set; }
    
    public Guid? CompanyId { get; set; }
    
    public Guid? ContactId { get; set; }
    
    public Guid AssignedToId { get; set; }

    public string Description { get; set; } = string.Empty;
    
    public decimal LeadValue { get; set; }
    
    public LeadOrigin LeadOrigin { get; set; }

    public List<Product> Products { get; set; } = [];
    
}