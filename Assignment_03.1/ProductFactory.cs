public class ProductFactory
{
    public Product CreateProduct(ProductCategory category)
    {
        if (category == ProductCategory.Electronics)
        {
            return new ElectronicsProduct();
        }
        else if (category == ProductCategory.Clothing)
        {
            return new ClothingProduct();
        }
        else if (category == ProductCategory.Books)
        {
            return new BookProduct();
        }
        else if (category == ProductCategory.HomeGarden)
        {
            return new HomeGardenProduct();
        }
        else
        {
            return null;
        }
    }
}
