using Application.UseCases.Suppliers.Dto;

namespace Application.UseCases.Suppliers.Queries.GetSupplierById;

public record GetSupplierByIdQuery(string Id) : IRequest<SupplierDto>;