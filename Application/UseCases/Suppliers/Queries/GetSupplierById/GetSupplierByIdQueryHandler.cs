using Application.Common.Exceptions;
using Application.UseCases.Suppliers.Dto;
using Domain.Entities;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Suppliers.Queries.GetSupplierById;

public class GetSupplierByIdQueryHandler : IRequestHandler<GetSupplierByIdQuery, SupplierDto>
{
    private readonly SupplierService _service;
    private readonly IMapper _mapper;

    public GetSupplierByIdQueryHandler(SupplierService service,
        IMapper mapper) =>
        (_service, _mapper) = (service, mapper);

    public async Task<SupplierDto> Handle(GetSupplierByIdQuery request, CancellationToken cancellationToken)
    {
        var supplierSearched = await _service.GetSupplierById(request.Id);
        _ = supplierSearched ?? throw new EntityException("Entidad no encontrada");
        return _mapper.Map<SupplierDto>(supplierSearched);
    }
}