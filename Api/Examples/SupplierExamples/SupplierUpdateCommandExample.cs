using Application.UseCases.Suppliers.Commands.SupplierUpdate;
using MongoDB.Bson;
using Swashbuckle.AspNetCore.Filters;

namespace Api.Examples.SupplierExamples
{
    public class SupplierUpdateCommandExample : IMultipleExamplesProvider<SupplierUpdateCommand>
    {
        public IEnumerable<SwaggerExample<SupplierUpdateCommand>> GetExamples()
        {
            var supplierCommand = new SupplierUpdateCommand(
                ObjectId.GenerateNewId().ToString()!,
                "BusinessName One",
                "Calle 1",
                "Ciudad 1",
                "Departamento 1",
                "Email@example.com",
                true,
                "Contact Name",
                "Contactemail@example.com"
            );
            yield return SwaggerExample.Create("supplierUpdateCommand", supplierCommand);
        }
    }
}