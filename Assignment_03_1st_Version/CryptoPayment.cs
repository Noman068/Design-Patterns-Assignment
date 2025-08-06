public class CryptoPayment : IPaymentStrategy
{
    private string walletAddress;

    public CryptoPayment()
    {
        Console.Write("Enter Crypto Wallet Address: ");
        walletAddress = Console.ReadLine();
    }

    public bool Pay(decimal amount)
    {
        if (string.IsNullOrEmpty(walletAddress))
        {
            Console.WriteLine("Crypto payment failed: Wallet address missing.");
            return false;
        }

        Console.WriteLine("Processing crypto payment of $" + amount + " to wallet: " + walletAddress);
        return true;
    }
}
