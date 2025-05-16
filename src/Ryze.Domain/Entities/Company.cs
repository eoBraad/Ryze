namespace Ryze.Domain.Entities;

public class Company : BaseEntity
{
    public string CompanyName { get; set; } = string.Empty;

    public string? CompanyPhone { get; set; }

    public int? CompanyEmployees { get; set; }
    
    public string? CompanyLogoUrl { get; set; } 

    public string? CompanyAddress { get; set; } 

    public decimal? CompanyRevenuePerYear { get; set; }

    public string? CompanyWebsite { get; set; } 

    public string? CompanyDescription { get; set; } 

    public string? CompanyCnpj { get; set; }
}