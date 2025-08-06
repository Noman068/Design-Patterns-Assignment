public class PaymentContext
{
    private IPaymentStrategy _strategy;

    public void SetStrategy(IPaymentStrategy strategy)
    {
        _strategy = strategy;
    }

    public bool Pay(decimal amount)
    {
        if (_strategy == null)
        {
            Console.WriteLine("Payment method not selected.");
            return false;
        }
        return _strategy.Pay(amount);
    }
}
