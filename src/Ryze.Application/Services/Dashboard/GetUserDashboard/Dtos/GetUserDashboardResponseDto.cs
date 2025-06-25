namespace Ryze.Application.Services.Dashboard.GetUserDashboard.Dtos;

public class GetUserDashboardResponseDto
{
    public List<Domain.Entities.Lead> UserLeads { get; set; }
    public int TotalLeadsMonthly { get; set; }
    public int TotalPages { get; set; }
    public int Page { get; set; }
}