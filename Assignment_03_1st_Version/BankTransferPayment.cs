public class BankTransferPayment : IPaymentStrategy
{
    private string routingNumber;
    private string accountNumber;

    public BankTransferPayment()
    {
        Console.Write("Enter Routing Number: ");
        routingNumber = Console.ReadLine();

        Console.Write("Enter Account Number: ");
        accountNumber = Console.ReadLine();
    }

    public bool Pay(decimal amount)
    {
        if (string.IsNullOrEmpty(routingNumber) || string.IsNullOrEmpty(accountNumber))
        {
            Console.WriteLine("Bank transfer failed: Missing routing or account number.");
            return false;
        }

        Console.WriteLine("Processing bank transfer of $" + amount);
        return true;
    }
}
