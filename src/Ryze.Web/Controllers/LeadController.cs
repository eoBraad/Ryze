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
    public async Task<IActionResult> CreateLead([FromBody] UserCreateLeadRequestDto dto, [FromServices] UserCreateLeadService service)
    {
        await service.CreateLeadAsync(dto, Guid.Parse(this.User.Claims.First(c => c.Type == ClaimTypes.Sid).Value));
        return Created("", null);
    }
}