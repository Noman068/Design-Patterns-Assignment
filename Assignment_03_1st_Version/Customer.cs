public class Customer
{
    public string CustomerId;
    public string Name;

    public Customer(string name)
    {
        CustomerId = Guid.NewGuid().ToString();
        Name = name;
    }
}
