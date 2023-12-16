using System.Net;
using Application.Common;
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
            var modelResponse = new Response<string>() { Succeded = false, Message = error?.Message };

            switch (error)
            {
                case ApiException e:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case ValidationException e:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    modelResponse.Errors = e.Errors;
                    break;
                case CustomException e:
                    modelResponse.Errors = e.ErrorMessages;
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case KeyNotFoundException e:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                case CoreBusinessException e:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            var result = JsonSerializer.Serialize(modelResponse);
            await response.WriteAsync(result);
        }
    }
}