namespace HyperStoreEntities.Logger;

// Make it singleton
internal class FileLogger : ILog
{
    const string LOG_FILE_NAME = "log1.txt";
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
}
