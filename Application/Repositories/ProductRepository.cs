using Application.IRepositories;
using Domain;
using Domain.Enums;
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
        var categoryBound = Enum.GetNames(typeof(CategoryEnum)).Count() - 1;
        if ((int)product.Category < 0 || (int)product.Category > categoryBound)
        {
            throw new ArgumentException($"Product with category {product.Category} is out of scoped!");
        }
        var statusBound = Enum.GetNames(typeof(ProductStatusEnum)).Count() - 1;
        if ((int)product.Status < 0 || (int)product.Status > statusBound)
        {
            throw new ArgumentException($"Product with status {product.Status} is out of scoped!");
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
            throw new ArgumentException($"Product with Id {product.Id} does not exist!");
        }
        var categoryBound = Enum.GetNames(typeof(CategoryEnum)).Count() - 1;
        if ((int)product.Category < 0 || (int)product.Category > categoryBound)
        {
            throw new Exception($"Product with category {product.Category} is out of scoped!");
        }
        var statusBound = Enum.GetNames(typeof(ProductStatusEnum)).Count() - 1;
        if ((int)product.Status < 0 || (int)product.Status > statusBound)
        {
            throw new Exception($"Product with status {product.Status} is out of scoped!");
        }
        await _productDao.UpdateAsync(product);
    }

    public List<string> GetAllCategories()
    {
        var categories = Enum.GetNames(typeof(CategoryEnum));
        return categories.ToList();
    }

    public List<string> GetAllStatus()
    {
        var status = Enum.GetNames(typeof(ProductStatusEnum));
        return status.ToList();
    }

    public async Task HardDeleteProductAsync(int productId)
    {
        var product = await GetProductByIdAsync(productId);
        if (product == null)
        {
            throw new ArgumentException($"Product with Id {productId} does not exist.");
        }
        await _productDao.DeleteAsync(product);
    }
}

