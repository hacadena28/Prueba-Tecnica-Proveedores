using System.Linq.Expressions;
using Domain.Entities;
using Domain.Ports;

namespace Domain.Services;

public class SupplierService
{
    private readonly IGenericRepository<Supplier> _supplierRepository;

    public SupplierService(IGenericRepository<Supplier> supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }

    public async Task<Supplier> GetSupplierById(string supplierId)
    {
        return await _supplierRepository.GetById(supplierId);
    }

    public async Task<IEnumerable<Supplier>> Find(Expression<Func<Supplier, bool>> filter)
    {
        return await _supplierRepository.FindAsync(filter);
    }

    public async Task<IEnumerable<Supplier>> GetAllSupplier()
    {
        return await _supplierRepository.GetAll();
    }

    public async Task CreateSupplier(Supplier supplier)
    {
        await _supplierRepository.Add(supplier);
    }

    public async Task UpdateSupplier
    (
        string? supplierId,
        string? businessName,
        SupplierAddress? supplierAddress,
        string? email,
        bool? active,
        string? contactName,
        string? contactEmail
    )
    {
        var supplierSearched = await _supplierRepository.GetById(supplierId);
        if (supplierSearched.Active != active && active != null)
        {
            supplierSearched.ChangeState(active.Value);
        }

        supplierSearched.Update(businessName, supplierAddress, email, contactName, contactEmail);
        await _supplierRepository.Update(supplierSearched);
    }

    public async Task DeleteSupplier(Supplier supplier)
    {
        supplier.ChangeState(false);
        await _supplierRepository.Delete(supplier);
    }

    public async Task<bool> ExistSupplier(string supplierId)
    {
        return await _supplierRepository.Exist(supplierId);
    }
}