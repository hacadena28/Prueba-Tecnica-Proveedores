using System.Net;
using Application.Common.Exceptions;
using Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Infrastructure.Middleware;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            var modelResponse = new Response<string>() { Succeded = false, Message = error.Message };

            switch (error)
            {
                case ValidationException e:
                    await e.HandleError(context, modelResponse);
                    break;
                case CustomException e:
                    await e.HandleError(context);
                    break;
                case CoreBusinessException e:
                    await e.HandleError(context);
                    break;
                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            var result = JsonSerializer.Serialize(modelResponse);
            await response.WriteAsync(result);
        }
    }
}