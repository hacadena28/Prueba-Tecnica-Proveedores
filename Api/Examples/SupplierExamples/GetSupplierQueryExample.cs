using Application.UseCases.Suppliers.Queries.GetSuppliers;
using Swashbuckle.AspNetCore.Filters;

namespace Api.Examples.SupplierExamples
{
    public class GetSupplierQueryExample : IMultipleExamplesProvider<GetAllSuppliersQuery>
    {
        public IEnumerable<SwaggerExample<GetAllSuppliersQuery>> GetExamples()
        {
            var supplierQuery = new GetAllSuppliersQuery(
                );
            yield return SwaggerExample.Create("supplierQuery", supplierQuery);
        }
    }
}