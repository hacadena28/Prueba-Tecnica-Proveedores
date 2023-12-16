using Application.UseCases.Auth.Commands.Authentication;
using Application.UseCases.Suppliers.Queries.GetSupplierById;
using MongoDB.Bson;
using Swashbuckle.AspNetCore.Filters;

namespace Api.Examples.AuthExamples;

public class AuthenticationCommandExample : IMultipleExamplesProvider<AuthenticationCommand>
{
    public IEnumerable<SwaggerExample<AuthenticationCommand>> GetExamples()
    {
        var authQuery = new AuthenticationCommand(
            "admin",
            "12345678"
        );
        yield return SwaggerExample.Create("authQuery", authQuery);
    }
}