using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ryze.Application.Services.User.CreateUser;
using Ryze.Application.Services.User.CreateUser.Dtos;
using Ryze.Domain.Enums;

namespace Ryze.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 200)]
    [Authorize($"CreateUserRequirement")]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequestDto dto,
        [FromServices] CreateUserService service)
    {
        var result = await service.CreateUserAsync(dto);
        return Created(result.ToString(), null);
    }
}