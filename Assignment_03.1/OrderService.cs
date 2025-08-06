public class OrderService
{
    private IOrderRepository _orderRepo;
    private ILogger _logger;

    public OrderService(IOrderRepository orderRepo, ILogger logger)
    {
        _orderRepo = orderRepo;
        _logger = logger;
    }

    public Order CreateOrder(string customerId, List<Product> products)
    {
        Order order = new Order();
        order.CustomerId = customerId;

        foreach (var product in products)
        {
            order.AddProduct(product);
        }

        _orderRepo.Add(order);
        _logger.LogInfo("Order created for customer: " + customerId);
        return order;
    }

    public void ShowOrders()
    {
        var orders = _orderRepo.GetAll();
        foreach (var order in orders)
        {
            order.DisplayOrder();
            Console.WriteLine("---------------------");
        }
    }
}
