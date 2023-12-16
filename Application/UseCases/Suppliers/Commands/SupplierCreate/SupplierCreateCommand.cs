namespace Application.UseCases.Suppliers.Commands.SupplierCreate;

public record SupplierCreateCommand(
    string Nit,
    string BusinessName,
    string Address,
    string City,
    string Department,
    string Email,
    string ContactName,
    string ContactEmail
) : IRequest;