public class PayPalPayment : IPaymentStrategy
{
    private string email;
    private string password;

    public PayPalPayment()
    {
        Console.Write("Enter PayPal Email: ");
        email = Console.ReadLine();

        Console.Write("Enter PayPal Password: ");
        password = Console.ReadLine();
    }

    public bool Pay(decimal amount)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            Console.WriteLine("PayPal payment failed: Email or password missing.");
            return false;
        }

        Console.WriteLine("Processing PayPal payment of $" + amount + " for " + email);
        return true;
    }
}
