namespace Ryze.Application.Services.Login.RefreshJwt.Dto;

public class RefreshTokenResponseDto
{
    public string AccessToken { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
}