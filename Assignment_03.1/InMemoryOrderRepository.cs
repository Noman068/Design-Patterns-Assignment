public class InMemoryOrderRepository : IOrderRepository
{
    private List<Order> _orders = new List<Order>();

    public void Add(Order order)
    {
        _orders.Add(order);
    }

    public List<Order> GetAll()
    {
        return _orders;
    }

    public List<Order> GetOrdersByCustomer(string customerId)
    {
        List<Order> result = new List<Order>();
        foreach (var order in _orders)
        {
            if (order.CustomerId == customerId)
            {
                result.Add(order);
            }
        }
        return result;
    }
}
