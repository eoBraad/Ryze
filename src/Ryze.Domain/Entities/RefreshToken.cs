namespace Ryze.Domain.Entities;

public class RefreshToken : BaseEntity
{
    public string Token { get; set; }
    
    public DateTime ExpirationDate { get; set; }
    
    public bool IsRevoked { get; set; }
    
    public Guid UserId { get; set; }
    
}