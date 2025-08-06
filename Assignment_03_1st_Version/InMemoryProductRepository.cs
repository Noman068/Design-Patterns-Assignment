using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class InMemoryProductRepository : IProductRepository
{
    private readonly List<Product> _products = new List<Product>();

    public Task AddAsync(Product product)
    {
        _products.Add(product);
        return Task.CompletedTask;
    }

    public Task<List<Product>> GetAllAsync()
    {
        return Task.FromResult(_products.ToList());
    }

    public Task<Product> GetByIdAsync(string id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        return Task.FromResult(product);
    }

    public Task UpdateAsync(Product product)
    {
        var index = _products.FindIndex(p => p.Id == product.Id);
        if (index >= 0)
        {
            _products[index] = product;
        }
        return Task.CompletedTask;
    }

    public Task DeleteAsync(string id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            _products.Remove(product);
        }
        return Task.CompletedTask;
    }

    public Task<List<Product>> GetByCategoryAsync(ProductCategory category)
    {
        var products = _products.Where(p => p.Category == category).ToList();
        return Task.FromResult(products);
    }

    public Task<List<Product>> GetLowStockProductsAsync(int threshold)
    {
        var lowStock = _products.Where(p => p.Stock < threshold).ToList();
        return Task.FromResult(lowStock);
    }
}
