namespace Application.UseCases.Suppliers.Commands.SupplierUpdate;

public record SupplierUpdateCommand
(
    string SupplierId,
    string? BusinessName,
    string? Address,
    string? City,
    string? Department,
    string? Email,
    bool? Active,
    string? ContactName,
    string? ContactEmail
) : IRequest;