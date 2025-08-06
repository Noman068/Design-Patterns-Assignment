public class PaymentService
{
    private PaymentContext _context;
    private ILogger _logger;

    public PaymentService(PaymentContext context, ILogger logger)
    {
        _context = context;
        _logger = logger;
    }

    public void ProcessPayment(decimal amount)
    {
        bool result = _context.Pay(amount);
        if (result)
        {
            _logger.LogInfo("Payment successful: $" + amount);
        }
        else
        {
            _logger.LogError("Payment failed.");
        }
    }
}
