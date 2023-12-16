using Domain.Entities;

namespace Application.UseCases.Suppliers.Dto;

public record SupplierDto(
    string Id,
    string Nit,
    string BusinessName,
    SupplierAddress SupplierAddress,
    string Email,
    bool Active,
    string ContactName,
    string ContactEmail
)
{
}