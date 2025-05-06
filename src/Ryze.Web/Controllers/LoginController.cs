using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ryze.Application.Services.User.GetAuthenticatedUser;
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
    
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetCurrentAuthenticatedUser([FromServices] IGetAuthenticatedUser service)
    {
        var user = await service.ExecuteAsync(Guid.Parse(User.FindFirst("id")!.Value));
        
        if (user == null)
        {
            return NotFound();
        }
        
        return Ok(user);
    }
}