using System.Net;
using Domain;
using Microsoft.AspNetCore.Http;

namespace Application.Common.Exceptions;

public class EntityExistingException : CustomException
{
    public EntityExistingException() : base(Messages.EntityExistingException)
    {
    }

    public EntityExistingException(string message)
        : base(message, null)
    {
    }

    public async override Task HandleError(HttpContext context)
    {
        context.Response.StatusCode = (int)HttpStatusCode.Conflict;
    }
}