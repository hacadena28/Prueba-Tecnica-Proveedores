using Domain.Exceptions;
using Swashbuckle.AspNetCore.Filters;

namespace Api.Examples.SupplierExamples;

public class SupplierByIdNoFound : IMultipleExamplesProvider<Response<string>>
{
    public IEnumerable<SwaggerExample<Response<string>>> GetExamples()
    {
        var response = new Response<string>("Recurso no encontrado");


        yield return SwaggerExample.Create("Recurso no encontrado", response);
    }
}