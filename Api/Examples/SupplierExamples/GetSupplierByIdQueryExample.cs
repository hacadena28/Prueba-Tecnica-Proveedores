using Application.UseCases.Suppliers.Queries.GetSupplierById;
using MongoDB.Bson;
using Swashbuckle.AspNetCore.Filters;

namespace Api.Examples.SupplierExamples
{
    public class GetSupplierByIdQueryExample : IMultipleExamplesProvider<GetSupplierByIdQuery>
    {
        public IEnumerable<SwaggerExample<GetSupplierByIdQuery>> GetExamples()
        {
            var supplierQuery = new GetSupplierByIdQuery(
                ObjectId.GenerateNewId().ToString()!
            );
            yield return SwaggerExample.Create("supplierQuery", supplierQuery);
        }
    }
}