namespace Application.UseCases.Suppliers.Commands.SupplierDelete;

public record SupplierDeleteCommand(string SupplierId) : IRequest;
