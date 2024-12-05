namespace DatabaseBackupUtility.Core;

public class DbConfig
{
    public string Database { get; set; }
    public string Server { get; set; }
    public string UserId { get; set; }
    public string Password { get; set; }
    public string Port { get; set; }
    public string StorageLocation { get; set; }
    public string BackupName { get; set; }
    public string RestoreDbName { get; set; }
    public string RestoreMdfPath { get; set; }
    public string RestoreLdfPath { get; set; }
}