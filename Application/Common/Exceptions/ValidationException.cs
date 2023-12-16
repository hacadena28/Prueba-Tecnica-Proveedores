using System.Net;
using Domain;
using Domain.Exceptions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;

namespace Application.Common.Exceptions;

public class ValidationException : Exception
{
    public ValidationException() : base(Messages.ValidationException)
    {
        Errors = new List<string>();
    }

    public List<string> Errors { get; }

    public ValidationException(IEnumerable<string> failures) : this()
    {
        Errors = failures.ToList();
    }
    
    public async Task HandleError(HttpContext context, Response<string> response)
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        response.Errors = Errors;
    }
}