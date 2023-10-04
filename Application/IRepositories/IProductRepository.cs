using Domain;

namespace Application.IRepositories;

public interface IProductRepository
{
    Task<List<Product>> GetAllProductsAsync();
    Task<List<Product>> GetProductByNameAsync(string name);
    Task<Product?> GetProductByIdAsync(int productId);
    Task AddProductAsync(Product product);
    Task UpdateProductAsync(Product product);
    Task DeleteProductAsync(int productId);
}

