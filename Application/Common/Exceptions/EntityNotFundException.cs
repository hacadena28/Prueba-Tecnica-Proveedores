using System.Net;
using Domain;
using Microsoft.AspNetCore.Http;

namespace Application.Common.Exceptions;

public class EntityNotFundException : CustomException
{
    public EntityNotFundException() : base(Messages.EntityNotFundException)
    {
    }

    public EntityNotFundException(string message)
        : base(message, null)
    {
    }

    public async override Task HandleError(HttpContext context)
    {
        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
    }
}