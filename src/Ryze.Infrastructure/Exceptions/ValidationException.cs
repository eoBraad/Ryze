using System.Net;

namespace Ryze.Infrastructure.Exceptions;

public class ValidationException(List<string> errorMessages) : RyzeException(string.Empty)
{
    public override int StatusCode => (int)HttpStatusCode.BadRequest;

    public override List<string> GetErrors()
    {
        return errorMessages;
    }
}