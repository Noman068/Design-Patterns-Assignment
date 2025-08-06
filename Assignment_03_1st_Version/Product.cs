public enum ProductCategory
{
    Electronics,
    Clothing,
    Books,
    HomeGarden
}

public abstract class Product
{
    public string Id;
    public string Name;
    public ProductCategory Category;
    public decimal Price;
    public int Stock;

    public Product()
    {
        Id = Guid.NewGuid().ToString();
    }

    public abstract string GetProductDetails();
}


