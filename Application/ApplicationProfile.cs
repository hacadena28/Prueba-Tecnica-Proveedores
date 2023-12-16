using Application.UseCases.Suppliers.Dto;
using Domain.Entities;

namespace Application;

public class ApplicationProfile : Profile
{
    public ApplicationProfile()
    {
        CreateMap<Supplier, SupplierDto>().ReverseMap();
    }
}