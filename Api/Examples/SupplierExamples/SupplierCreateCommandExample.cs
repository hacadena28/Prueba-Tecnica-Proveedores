using Application.UseCases.Suppliers.Commands.SupplierCreate;
using Swashbuckle.AspNetCore.Filters;

namespace Api.Examples.SupplierExamples
{
    public class SupplierCreateCommandExample : IMultipleExamplesProvider<SupplierCreateCommand>
    {
        public IEnumerable<SwaggerExample<SupplierCreateCommand>> GetExamples()
        {
            var supplierCommand = new SupplierCreateCommand(
                "12345678",
                    "Bussiness One",
                "Calle 1",
                "Ciudad 1",
                "Departamento 1",
                "Email@example.com0",
                "Name Contact",
                "contactemail@example.com"
            );
            yield return SwaggerExample.Create("supplierCreateCommand", supplierCommand);
        }
    }
}