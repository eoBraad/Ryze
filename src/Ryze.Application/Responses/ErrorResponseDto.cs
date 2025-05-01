namespace Ryze.Application.Responses;

public class ErrorResponseDto(List<string> errorMessages)
{
    public List<string> ErrorMessages { get; set; } = errorMessages;
}