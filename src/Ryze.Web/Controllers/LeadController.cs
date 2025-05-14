using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ryze.Application.Services.Lead.UserCreateLead;
using Ryze.Application.Services.Lead.UserCreateLead.Dtos;

namespace Ryze.Web.Controllers;


[ApiController]
[Route("api/[controller]")]
public class LeadController : ControllerBase
{
    [HttpPost("user")]
    [Authorize]
    public async Task<IActionResult> CreateLead([FromBody] UserCreateLeadRequestDto request, [FromServices] UserCreateLeadService service)
    {
        var userId = Guid.Parse(User.FindFirst(ClaimTypes.Sid)!.Value);
        await service.CreateLeadAsync(request, userId);
        return Created("", null);
    }
}