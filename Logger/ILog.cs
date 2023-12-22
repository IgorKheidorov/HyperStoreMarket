
namespace HyperStoreEntities.Logger;

internal interface ILog
{
    void LogMessage(string? message);
    Task LogMessageAsync(string? message);
}
