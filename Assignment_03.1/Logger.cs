
public class Logger : ILogger
{
    private static Logger _instance;
    private static object _lock = new object();

    private Logger() { }

    public static Logger GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Logger();
                }
            }
        }
        return _instance;
    }

    public void LogInfo(string message)
    {
        Console.WriteLine("[INFO] " + DateTime.Now.ToString() + " - " + message);
    }

    public void LogWarning(string message)
    {
        Console.WriteLine("[WARNING] " + DateTime.Now.ToString() + " - " + message);
    }

    public void LogError(string message)
    {
        Console.WriteLine("[ERROR] " + DateTime.Now.ToString() + " - " + message);
    }
}