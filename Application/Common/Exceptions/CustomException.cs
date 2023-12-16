using System.Net;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Http;

namespace Application.Common.Exceptions;

public class CustomException : Exception
{
    public CustomException()
    {
    }

    public CustomException(string message) : base(message)
    {
    }

    public CustomException(string message, Exception inner) : base(message, inner)
    {
    }

    protected CustomException(SerializationInfo info, StreamingContext content) : base(info, content)
    {
    }

    public async virtual Task HandleError(HttpContext context)
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
    }
}