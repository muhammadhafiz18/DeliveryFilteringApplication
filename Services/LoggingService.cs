namespace DeliveryOrderFilter.Services;

public static class LoggingService
{
    private static readonly string logFilePath = "logs.csv";

    public static void Log(string message)
    {
        try
        {
            File.AppendAllText(logFilePath, $"{DateTime.Now}: {message}\n");
        }
        catch (Exception ex)
        {
            File.AppendAllText(logFilePath, $"{DateTime.Now}: Failed to log message: {ex.Message} in LoggingService.cs, line 15.\n--------------------------------");
            Console.WriteLine($"Failed to log message: {ex.Message}");
        }
    }
}

