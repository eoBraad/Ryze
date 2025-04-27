namespace Ryze.Domain.Entities;

public class Company : BaseEntity
{
    public string CompanyName { get; set; } = string.Empty;

    public string CompanyPhone { get; set; } = string.Empty;

    public int CompanyEmployees { get; set; }

    public string CompanyAddress { get; set; } = string.Empty;

    public decimal CompanyRevenuePerYear { get; set; }

    public string CompanyWebsite { get; set; } = string.Empty;

    public string CompanyDescription { get; set; } = string.Empty;

    public string CompanyCnpj { get; set; } = string.Empty;
}