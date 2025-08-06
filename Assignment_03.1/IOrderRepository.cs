public interface IOrderRepository
{
    void Add(Order order);
    List<Order> GetAll();
    List<Order> GetOrdersByCustomer(string customerId);
}
