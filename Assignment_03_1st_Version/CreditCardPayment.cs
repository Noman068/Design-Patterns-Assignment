public class CreditCardPayment : IPaymentStrategy
{
    public bool Pay(decimal amount)
    {
        Console.WriteLine("Processing Credit Card Payment of $" + amount);
        return true;
    }
}
