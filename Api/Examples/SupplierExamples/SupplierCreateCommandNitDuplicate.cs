using Domain.Exceptions;
using Swashbuckle.AspNetCore.Filters;

namespace Api.Examples.SupplierExamples;

public class SupplierCreateCommandNitDuplicate : IMultipleExamplesProvider<Response<string>>
{
    public IEnumerable<SwaggerExample<Response<string>>> GetExamples()
    {
        var response = new Response<string>("Recurso ya registrado");


        yield return SwaggerExample.Create("Recurso ya registrado", response);
    }
}