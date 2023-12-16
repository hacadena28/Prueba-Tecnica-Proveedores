using Application.UseCases.Auth.Dto;
using Application.UseCases.Suppliers.Dto;
using Domain.Entities;
using MongoDB.Bson;
using Swashbuckle.AspNetCore.Filters;

namespace Api.Examples.SupplierExamples;

public class GetSupplierByIdResponseExample : IMultipleExamplesProvider<SupplierDto>
{
    public IEnumerable<SwaggerExample<SupplierDto>> GetExamples()
    {
        var supplierDto = new SupplierDto(
            ObjectId.GenerateNewId().ToString()!,
            "12345678",
            "Business One",
            new SupplierAddress(
                "calle 1",
                "ciudad 1",
                "departamento 1"
            ),
            "email@example.com",
            true,
            "Contact Name 1",
            "Contactemail@example.com"
        );

        yield return SwaggerExample.Create("supplierDto", supplierDto);
    }
}