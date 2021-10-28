namespace MyNamespace;

public class ProductRepository : IProductRepository
{
    public Task<Product> GetProductAsync(int id) =>
        Task.FromResult<Product>(new(1, "Name", ProductWarranty.OneYear));
}
public interface IProductRepository
{
    Task<Product> GetProductAsync(int id);
}

public record class Product(int Id, string Name, ProductWarranty Warranty);

public enum ProductWarranty
{
    Unlimited,
    OneYear,
    TwoYears
}
