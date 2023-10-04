using Application.IRepositories;
using Domain;
using Infrastructure.Daos;

namespace Application.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ProductDao _productDao;

    public ProductRepository(ProductDao productDao)
    {
        _productDao = productDao;
    }

    public async Task AddProductAsync(Product product)
    {
        var existingProduct = await GetProductByIdAsync(product.Id);
        if (existingProduct != null)
        {
            throw new ArgumentException($"Product with Id {product.Id} already exists!");
        }
        await _productDao.AddAsync(product);
    }

    public async Task DeleteProductAsync(int productId)
    {
        var product = await GetProductByIdAsync(productId);
        if (product == null)
        {
            throw new ArgumentException($"Product with Id {productId} does not exist.");
        }
        await _productDao.SoftDeleteAsync(product);
    }

    public async Task<List<Product>> GetProductByNameAsync(string name)
    {
        return (await _productDao.GetAllAsync())
                        .Where(x => x.Name.ToUpper().Contains(name.ToUpper()))
                        .ToList();
    }

    public async Task<Product?> GetProductByIdAsync(int productId)
    {
        return await _productDao.GetByIdAsync(productId);
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        return await _productDao.GetAllAsync();
    }

    public async Task UpdateProductAsync(Product product)
    {
        var existingProduct = await GetProductByIdAsync(product.Id);
        if (existingProduct == null)
        {
            throw new ArgumentException($"Product with Id {product.Id} does not exist.");
        }
        await _productDao.UpdateAsync(product);
    }
}

