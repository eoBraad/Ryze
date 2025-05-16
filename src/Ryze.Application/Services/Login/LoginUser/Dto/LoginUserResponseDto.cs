namespace Ryze.Application.Services.Login.LoginUser.Dto;

public class LoginUserResponseDto
{
    public string Token { get; set; }
    public int StatusCode { get; set; }
    
    public string RefreshToken { get; set; }
}