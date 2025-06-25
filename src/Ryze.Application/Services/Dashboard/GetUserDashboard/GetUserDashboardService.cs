using Ryze.Application.Services.Dashboard.GetUserDashboard.Dtos;
using Ryze.Domain.Interfaces.Repositories;

namespace Ryze.Application.Services.Dashboard.GetUserDashboard;

public class GetUserDashboardService(ILeadRepository LeadRepository)
{
    public async Task<GetUserDashboardResponseDto> GetUserDashboard(Guid userId, int page = 1, int pageSize = 25)
    {
        var userLeads = await LeadRepository.GetUserLeadsMonthlyAsync(userId, page, pageSize);
        var totalLeadsMonthly = await LeadRepository.GetTotalPagesAsync(page, pageSize);
        var totalPages = await LeadRepository.GetTotalPagesAsync(page, pageSize);

        return new GetUserDashboardResponseDto
        { 
            UserLeads = userLeads,
            TotalLeadsMonthly = totalLeadsMonthly,
            TotalPages = totalPages,
            Page = page
        };
    }
}