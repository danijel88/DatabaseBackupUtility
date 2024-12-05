using DatabaseBackupUtility.MsSqlAggregate;

namespace DatabaseBackupUtility;

public abstract class DatabaseRule
{
    public abstract bool IsMatch(string dbProvider, string action, string? backupType);
    public abstract Task ExecuteAction(DatabaseProxy proxy);
}