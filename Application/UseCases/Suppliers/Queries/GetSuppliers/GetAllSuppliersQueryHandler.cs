using Application.Common.Exceptions;
using Application.UseCases.Suppliers.Dto;
using Domain.Services;

namespace Application.UseCases.Suppliers.Queries.GetSuppliers;

public class GetAllSuppliersQueryHandler : IRequestHandler<GetAllSuppliersQuery, IEnumerable<SupplierDto>>
{
    private readonly SupplierService _service;
    private readonly IMapper _mapper;

    public GetAllSuppliersQueryHandler(SupplierService service, IMapper mapper) =>
        (_service, _mapper) = (service, mapper);

    public async Task<IEnumerable<SupplierDto>> Handle(GetAllSuppliersQuery request,
        CancellationToken cancellationToken)
    {
        var suppliersSearched = _mapper.Map<List<SupplierDto>>(await _service.GetAllSupplier());
        return suppliersSearched;
    }
}