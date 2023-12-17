using Microsoft.AspNetCore.Http;
using System.Net;
using System.Runtime.Serialization;

namespace Domain.Exceptions;

[Serializable]
public class CoreBusinessException : Exception
{
    public CoreBusinessException()
    {
    }

    public CoreBusinessException(string message) : base(message)
    {
    }

    public CoreBusinessException(string message, Exception inner) : base(message, inner)
    {
    }

    protected CoreBusinessException(SerializationInfo info, StreamingContext content) : base(info, content)
    {
    }

    public async virtual Task HandleError(HttpContext context)
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
    }
}