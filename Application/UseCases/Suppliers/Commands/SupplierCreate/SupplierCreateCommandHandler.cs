using Application.Common.Exceptions;
using Domain.Entities;
using Domain.Services;
using ApplicationException = System.ApplicationException;

namespace Application.UseCases.Suppliers.Commands.SupplierCreate;

public class SupplierCreateCommandHandler : IRequestHandler<SupplierCreateCommand>
{
    private readonly SupplierService _service;

    public SupplierCreateCommandHandler(SupplierService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    public async Task<Unit> Handle(SupplierCreateCommand request, CancellationToken cancellationToken)
    {
        var supplierAddress = new SupplierAddress(request.Address, request.City, request.Department);

        var supplier = new Supplier
        (
            request.Nit,
            request.BusinessName,
            supplierAddress,
            request.Email,
            request.ContactName,
            request.ContactEmail
        );
        var supplierSearcherd =await _service.Find(filter => filter.Nit == request.Nit);
        
        if (supplierSearcherd.Any())
        {
            throw new EntityExistingException($"Este Nit: {request.Nit} Ya esta registrado");
        }

        await _service.CreateSupplier(supplier);

        return Unit.Value;
    }
}