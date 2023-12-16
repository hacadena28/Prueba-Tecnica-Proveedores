using Application.Common.Exceptions;
using Domain.Entities;
using Domain.Services;

namespace Application.UseCases.Suppliers.Commands.SupplierUpdate;

public class SupplierUpdateCommandHandler : IRequestHandler<SupplierUpdateCommand>
{
    private readonly SupplierService _service;

    public SupplierUpdateCommandHandler(SupplierService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    public async Task<Unit> Handle(SupplierUpdateCommand request, CancellationToken cancellationToken)
    {
        var supplierAddress = new SupplierAddress();

        supplierAddress.Address = request.Address;
        supplierAddress.City = request.City;
        supplierAddress.Department = request.Department;

        var supplierSearched = _service.GetSupplierById(request.SupplierId);
        _ = supplierSearched ?? throw new EntityNotFundException();
        
        await _service.UpdateSupplier(
            request.SupplierId,
            request.BusinessName,
            supplierAddress,
            request.Email,
            request.Active,
            request.ContactName,
            request.ContactEmail
        );
        return Unit.Value;
    }
}