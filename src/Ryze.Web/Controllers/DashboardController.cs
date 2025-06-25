using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ryze.Application.Services.Dashboard.GetUserDashboard;

namespace Ryze.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DashboardController : ControllerBase
{
    [Authorize]
    [HttpGet("user")]
    public async Task<IActionResult> GetUserDashboard([FromServices] GetUserDashboardService service, [FromQuery] int page = 1, [FromQuery] int pageSize = 25)
    {
        var userId = Guid.Parse(User.FindFirst(ClaimTypes.Sid)!.Value);
        var result = await service.GetUserDashboard(userId, page, pageSize);
        return Ok(result);
    }
}