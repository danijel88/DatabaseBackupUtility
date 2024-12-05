using DatabaseBackupUtility.Helpers;

namespace DatabaseBackupUtility.MsSqlAggregate;

public class MsSqlRestoreRule : DatabaseRule
{
    /// <inheritdoc />
    public override bool IsMatch(string dbProvider, string action, string? backupType)
    {
        return dbProvider.ToLower() == "mssql" && action.ToLower() == "restore";
    }

    /// <inheritdoc />
    public override async Task ExecuteAction(DatabaseProxy proxy)
    {
        string restoreQuery = $"RESTORE DATABASE {MsSqlConfigData.GetRestoreDbName} FROM DISK = N'{MsSqlConfigData.GetStorageLocation()}\\{MsSqlConfigData.GetBackupName()}'" +
                              $"WITH MOVE N'{MsSqlConfigData.GetRestoreDbName}' TO N'{MsSqlConfigData.GetRestoreMdfPath()}'" +
                              $"MOVE N'{MsSqlConfigData.GetRestoreLdfPath()}', REPLACE;";
        DbSqlConnection connection = new DbSqlConnection();
        Console.WriteLine($"Restore started at: {DateTime.Now}");
        connection.RunQuery(restoreQuery);
        Console.WriteLine($"Restore finished at: {DateTime.Now}");
    }
}