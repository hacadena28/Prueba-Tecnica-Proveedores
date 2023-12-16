using System.Net;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Http;

namespace Domain.Exceptions;

public class IncorrectCredentialsException : CoreBusinessException
{
    public IncorrectCredentialsException() : base(Messages.IncorrectCredentialsException)
    {
    }

    public IncorrectCredentialsException(string message) : base(message)
    {
    }

    public IncorrectCredentialsException(string message, Exception inner) : base(message, inner)
    {
    }

    protected IncorrectCredentialsException(SerializationInfo info, StreamingContext content) : base(info, content)
    {
    }

    public async override Task HandleError(HttpContext context)
    {
        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
    }
}