using System.Collections.Generic;
using System.Threading.Tasks;

public interface IProductRepository : IRepository<Product>
{
    Task<List<Product>> GetByCategoryAsync(ProductCategory category);
    Task<List<Product>> GetLowStockProductsAsync(int threshold);
}

