public class Logger : ILogger
{
    private static readonly Logger _instance = new Logger();
    public static Logger Instance => _instance;

    private Logger() { }

    public void LogInfo(string message)
    {
        Console.WriteLine($"[INFO] [{DateTime.Now}] {message}");
    }

    public void LogError(string message)
    {
        Console.WriteLine($"[ERROR] [{DateTime.Now}] {message}");
    }

    public void LogWarning(string message)
    {
        Console.WriteLine($"[WARN] [{DateTime.Now}] {message}");
    }
}
