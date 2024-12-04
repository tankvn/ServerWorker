namespace ServerWorker;

public class Worker : BackgroundService
{
    // Create a static logger field
    private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

    public Worker(ILogger<Worker> logger)
    {
        //_logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Logger.Info("Worker running at: {time}", DateTimeOffset.Now);

                await Task.Delay(3000, stoppingToken);
            }
        }
        catch (OperationCanceledException)
        {
            // When the stopping token is canceled, for example, a call made from services.msc,
            // we shouldn't exit with a non-zero exit code. In other words, this is expected...
        }
        catch (Exception ex)
        {
            Logger.Error(GetExceptionInfo(ex, "Worker.cs"));

            // Terminates this process and returns an exit code to the operating system.
            // This is required to avoid the 'BackgroundServiceExceptionBehavior', which
            // performs one of two scenarios:
            // 1. When set to "Ignore": will do nothing at all, errors cause zombie services.
            // 2. When set to "StopHost": will cleanly stop the host, and log errors.
            //
            // In order for the Windows Service Management system to leverage configured
            // recovery options, we need to terminate the process with a non-zero exit code.
            Environment.Exit(1);
        }
    }

    private string GetExceptionInfo(Exception ex, string className)
    {
        var lineNumber = 0;
        const string lineSearch = ":line ";
        var index = ex.StackTrace.LastIndexOf(lineSearch);
        if (index != -1)
        {
            var lineNumberText = ex.StackTrace.Substring(index + lineSearch.Length);
            if (int.TryParse(lineNumberText, out lineNumber))
            {
            }
        }
        return $"{className}:line {lineNumber} | {ex.GetType()}: {ex.Message}";
    }
}
