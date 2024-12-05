namespace DatabaseBackupUtility;

public class DatabaseProxy(
    string dbProvider,
    string action,
    string? backupType,
    string? compression)
{
    public string DbProvider { get; private set; } = dbProvider;
    public string Action { get; private set; } = action;
    public string? BackupType { get; private set; } = backupType;
    public string? WithCompression { get; private set; } = compression;
}