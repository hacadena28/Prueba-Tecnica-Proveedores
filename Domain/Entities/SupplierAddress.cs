namespace Domain.Entities;

public class SupplierAddress
{
    public string Address { get; set; }
    public string City { get; set; }
    public string Department { get; set; }

    public SupplierAddress
    (
        string address,
        string city,
        string department
    )
    {
        Address = address;
        City = city;
        Department = department;
    }

    public SupplierAddress()
    {
    }

    public void Update
    (
        string? address,
        string? city,
        string? department
    )
    {
        if (address != null && !Address.Equals(address)) Address = address;
        if (city != null && !City.Equals(city)) City = city;
        if (department != null && !Department.Equals(department)) Department = department;
    }
}