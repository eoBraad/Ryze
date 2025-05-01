using Microsoft.AspNetCore.Mvc;
using Ryze.Application.Services.User.Login;
using Ryze.Application.Services.User.Login.Dtos;

namespace Ryze.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> LoginUser([FromBody] LoginUserRequestDto dto, [FromServices] ILoginUserService service)
    {
        var result = await service.LoginUser(dto);
        
        return Ok(result);
    }
}