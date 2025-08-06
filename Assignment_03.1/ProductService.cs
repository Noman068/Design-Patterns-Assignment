public class ProductService
{
    private IProductRepository _productRepo;

    public ProductService(IProductRepository productRepo)
    {
        _productRepo = productRepo;
    }

    public void AddProduct(Product product)
    {
        _productRepo.Add(product);
    }

    public List<Product> GetAllProducts()
    {
        return _productRepo.GetAll();
    }

    public void ShowAllProducts()
    {
        var products = GetAllProducts();
        foreach (var product in products)
        {
            Console.WriteLine(product.GetProductDetails());
        }
    }
}
