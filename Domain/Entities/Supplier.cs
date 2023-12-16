namespace Domain.Entities;

public class Supplier : EntityBase<string>
{
    public string Nit { get; set; }
    public string BusinessName { get; set; }
    public SupplierAddress SupplierAddress { get; set; }
    public string Email { get; set; }
    public bool Active { get; set; }
    public string ContactName { get; set; }
    public string ContactEmail { get; set; }

    public Supplier
    (
        string nit,
        string businessName,
        SupplierAddress supplierAddress,
        string email,
        string contactName,
        string contactEmail
    )
    {
        Nit = nit;
        BusinessName = businessName;
        SupplierAddress = supplierAddress;
        Email = email;
        Active = true;
        ContactName = contactName;
        ContactEmail = contactEmail;
    }

    public Supplier()
    {
    }

    public void Update
    (
        string? businessName,
        SupplierAddress? supplierAddress,
        string? email,
        string? contactName,
        string? contactEmail
    )
    {
        if (businessName != null && !BusinessName.Equals(businessName)) BusinessName = businessName;
        if (email != null && !Email.Equals(email)) Email = email;
        if (contactName != null && !ContactName.Equals(contactName)) ContactName = contactName;
        if (contactEmail != null && !ContactEmail.Equals(contactEmail)) ContactEmail = contactEmail;
        if (supplierAddress != null)
        {
            supplierAddress.Update(
                supplierAddress.Address,
                supplierAddress.City,
                supplierAddress.Department
            );
        }
    }

    public void ChangeState(bool newState)
    {
        if (newState != Active) Active = newState;
    }
}