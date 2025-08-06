public class InMemoryProductRepository : IProductRepository
{
    private List<Product> _products = new List<Product>();

    public void Add(Product product)
    {
        _products.Add(product);
    }

    public List<Product> GetAll()
    {
        return _products;
    }
}
