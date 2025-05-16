using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ryze.Application.Services.Login.GetAuthenticatedUser;
using Ryze.Application.Services.Login.LoginUser;
using Ryze.Application.Services.Login.RefreshJwt;
using Ryze.Application.Services.Login.RefreshJwt.Dto;
using Ryze.Application.Services.Login.GetAuthenticatedUser.Dto;
using Ryze.Application.Services.Login.LoginUser.Dto;

namespace Ryze.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(LoginUserResponseDto), 200)]
    public async Task<IActionResult> LoginUser([FromBody] LoginUserRequestDto dto, [FromServices] LoginUserService service)
    {
        var result = await service.LoginUser(dto);
        
        var jwtCookieOptions = new CookieOptions
        {
            HttpOnly = true,           
            Secure = false,             
            SameSite = SameSiteMode.Strict, 
            Expires = DateTime.UtcNow.AddMinutes(5)
        };

        Response.Cookies.Append("token", result.Token, jwtCookieOptions);
        
        var refreshCookieOptions = new CookieOptions
        {
            HttpOnly = true,           
            Secure = false,             
            SameSite = SameSiteMode.Strict, 
            Expires = DateTime.UtcNow.AddMinutes(5)
        };
        
        Response.Cookies.Append("refreshToken", result.RefreshToken, refreshCookieOptions);
        
        return Ok(result);
    }
    
    [HttpGet]
    [Authorize]
    [ProducesResponseType(typeof(GetAuthenticatedUserDto), 200)]
    public async Task<IActionResult> GetCurrentAuthenticatedUser([FromServices] GetAuthenticatedUser service)
    {
        var user = await service.ExecuteAsync(Guid.Parse(User.FindFirst(ClaimTypes.Sid)!.Value));
        
        if (user == null)
        {
            return NotFound();
        }
        
        return Ok(user);
    }

    [HttpPost($"refresh")]
    [ProducesResponseType(typeof(RefreshTokenResponseDto), 200)]
    public async Task<IActionResult> GetNewRefreshToken([FromBody] RefreshTokenRequestDto dto,
        [FromServices] RefreshJwtService service)
    {
        var result = await service.RefreshToken(dto);
        
        var jwtCookieOptions = new CookieOptions
        {
            HttpOnly = true,           
            Secure = false,             
            SameSite = SameSiteMode.Strict, 
            Expires = DateTime.UtcNow.AddMinutes(5)
        };

        Response.Cookies.Append("token", result.AccessToken, jwtCookieOptions);
        
        var refreshCookieOptions = new CookieOptions
        {
            HttpOnly = true,           
            Secure = false,             
            SameSite = SameSiteMode.Strict, 
            Expires = DateTime.UtcNow.AddMinutes(5)
        };
        
        Response.Cookies.Append("refreshToken", result.RefreshToken, refreshCookieOptions);
        
        return Ok(result);
    }
}