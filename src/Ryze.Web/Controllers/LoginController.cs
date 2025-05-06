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
        
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,           
            Secure = false,             
            SameSite = SameSiteMode.Strict, 
            Expires = DateTime.UtcNow.AddMinutes(5)
        };

        Response.Cookies.Append("token", result.Token, cookieOptions);
        
        return Ok(result);
    }
}