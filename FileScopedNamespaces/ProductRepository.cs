namespace FileScopedNamespaces;

public class ProductRepository : IProductRepository
{
    public Task<Product> GetProductAsync(int id) =>
        Task.FromResult<Product>(new(1, "Name", ProductWarranty.OneYear, new()));
}

public interface IProductRepository
{
    Task<Product> GetProductAsync(int id);
}

public record class Product(int Id, string Name, ProductWarranty Warranty, Address Address);

public readonly record struct Address(
    string Country,
    string City,
    string ZipCode)
{
    // [new] Parameterless constructors in structs​
    public Address() : this(
        AddressConstants.Country, AddressConstants.City, AddressConstants.ZipCode)
    {
    }
}

public static class AddressConstants
{
    // [new] Constant interpolated strings​
    public const string EPAM_Address = $"\"EPAM Systems Inc\" of {Country}, {ZipCode}";
    public const string Country = "United States";
    public const string City = "Newtown";
    public const string ZipCode = "PA 18940";
}

public enum ProductWarranty
{
    Unlimited,
    OneYear,
    TwoYears
}
