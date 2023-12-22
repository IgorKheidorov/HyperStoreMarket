namespace HyperStoreEntities.Logger;

// Make it singleton
internal class FileLogger : ILog
{
    const string LOG_FILE_NAME = "log_store_activity.txt";
    static FileLogger? _logger;
    private FileLogger() { }

    private readonly object _locker = new object(); // reference type

    public static FileLogger GetLogger()
    {
        if (_logger == null)
        {
            _logger = new FileLogger();
        }

        return _logger;
    }

    public void LogMessage(string? message)
    {
        lock (_locker) 
        {
            using (StreamWriter fsWrite = new StreamWriter(LOG_FILE_NAME, true))
            {
                fsWrite.WriteLine(message + DateTime.Now.ToString());
                fsWrite.Flush();
            }
        }
    }

    public async Task LogMessageAsync(string? message)
    {

        using (StreamWriter fsWrite = new StreamWriter(LOG_FILE_NAME, true))
        {
            TextWriter.Synchronized(fsWrite); // Make it thread safety
            await fsWrite.WriteLineAsync(message + DateTime.Now.ToString());   
        }
    }
    
}
