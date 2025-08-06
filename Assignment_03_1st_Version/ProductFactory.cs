public static class ProductFactory
{
    public static Product CreateProduct(ProductCategory category, string name, decimal price)
    {
        switch (category)
        {
            case ProductCategory.Electronics:
                return new ElectronicsProduct
                {
                    Name = name,
                    Price = price,
                    WarrantyMonths = 12
                };

            case ProductCategory.Books:
                return new BookProduct
                {
                    Name = name,
                    Price = price,
                    ISBN = "123-456-789"
                };

            case ProductCategory.Clothing:
                return new ClothingProduct
                {
                    Name = name,
                    Price = price,
                    Size = "M"
                };

            case ProductCategory.HomeGarden:
                return new HomeGardenProduct
                {
                    Name = name,
                    Price = price,
                    Material = "Wood"
                };

            default:
                throw new ArgumentException("Unsupported product category");
        }
    }
}
