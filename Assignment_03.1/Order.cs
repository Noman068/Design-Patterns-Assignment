public class Order
{
    public string OrderId;
    public string CustomerId;
    public List<Product> Products = new List<Product>();
    public decimal TotalAmount;

    public Order()
    {
        OrderId = Guid.NewGuid().ToString();
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);
        TotalAmount += product.Price;
    }

    public void DisplayOrder()
    {
        Console.WriteLine("Order ID: " + OrderId);
        Console.WriteLine("Customer ID: " + CustomerId);
        Console.WriteLine("Products:");
        foreach (var p in Products)
        {
            Console.WriteLine("- " + p.GetProductDetails());
        }
        Console.WriteLine("Total Amount: $" + TotalAmount);
    }
}
