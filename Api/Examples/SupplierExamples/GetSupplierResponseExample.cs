using Application.UseCases.Auth.Dto;
using Application.UseCases.Suppliers.Dto;
using Domain.Entities;
using MongoDB.Bson;
using Swashbuckle.AspNetCore.Filters;

namespace Api.Examples.SupplierExamples;

public class GetSupplierResponseExample : IMultipleExamplesProvider<IEnumerable<SupplierDto>>
{
    public IEnumerable<SwaggerExample<IEnumerable<SupplierDto>>> GetExamples()
    {
        var examples = new List<SupplierDto>();

        // Ejemplo 1
        examples.Add(new SupplierDto(
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
        ));

        // Ejemplo 2
        examples.Add(new SupplierDto(
            ObjectId.GenerateNewId().ToString()!,
            "87654321",
            "Business Two",
            new SupplierAddress(
                "calle 2",
                "ciudad 2",
                "departamento 2"
            ),
            "another_email@example.com",
            true,
            "Contact Name 2",
            "contact2_email@example.com"
        ));

        // Ejemplo 3
        examples.Add(new SupplierDto(
            ObjectId.GenerateNewId().ToString()!,
            "13579246",
            "Business Three",
            new SupplierAddress(
                "calle 3",
                "ciudad 3",
                "departamento 3"
            ),
            "third_email@example.com",
            true,
            "Contact Name 3",
            "contact3_email@example.com"
        ));

        yield return SwaggerExample.Create("supplierDto", examples.AsEnumerable());
    }
}