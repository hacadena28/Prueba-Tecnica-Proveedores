using Application.Common.Exceptions;
using Application.UseCases.Suppliers.Commands.SupplierCreate;
using Domain.Services;

namespace Application.UseCases.Suppliers.Commands.SupplierDelete;

public class SupplierDeleteCommandHandler : IRequestHandler<SupplierDeleteCommand>
{
    private readonly SupplierService _service;

    public SupplierDeleteCommandHandler(SupplierService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    public async Task<Unit> Handle(SupplierDeleteCommand request, CancellationToken cancellationToken)
    {
        var supplierSearched = await _service.GetSupplierById(request.SupplierId);
        _ = supplierSearched ?? throw new EntityNotFundException($"No existe ningun proveedor con este Id : {request.SupplierId}");
        await _service.DeleteSupplier(supplierSearched);
        return Unit.Value;
    }
}