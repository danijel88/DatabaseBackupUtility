using DatabaseBackupUtility.Helpers;

namespace DatabaseBackupUtility.MsSqlAggregate;

public class MsSqlDiffBackupRule : DatabaseRule
{
    /// <inheritdoc />
    public override bool IsMatch(string dbProvider, string action, string? backupType)
    {
        if (string.IsNullOrEmpty(backupType)) throw new ArgumentNullException(nameof(backupType), "Backup Type type must be inserted.");
        return dbProvider.ToLower() == "mssql" && action.ToLower() == "backup" && backupType!.ToLower() == "diff";
    }

    /// <inheritdoc />
    public override async Task ExecuteAction(DatabaseProxy proxy)
    {
        DbSqlConnection connection = new DbSqlConnection();
        string backupQuery = string.Empty;
        var result = await connection.TestConnection();
        if (!result)
        {
            Console.WriteLine("Can not open connection to database.");
            return;
        }

        if (proxy.WithCompression.ToLower() == "y")
        {
            backupQuery = $"USE {MsSqlConfigData.GetDatabaseName()}; GO" +
                          $" BACKUP DATABASE {MsSqlConfigData.GetDatabaseName()} TO " +
                          $"DISK='{MsSqlConfigData.GetStorageLocation()}\\{MsSqlConfigData.GetBackupName()}' WITH DIFFERENTIAL,COMPRESSION " +
                          $"MEDIANAME='{MsSqlConfigData.GetDatabaseName()}', " +
                          $"NAME = 'Differential backup of {MsSqlConfigData.GetDatabaseName()}'";
        }
        else
        {
            backupQuery = $"USE {MsSqlConfigData.GetDatabaseName()}; GO" +
                          $" BACKUP DATABASE {MsSqlConfigData.GetDatabaseName()} TO " +
                          $"DISK='{MsSqlConfigData.GetStorageLocation()}\\{MsSqlConfigData.GetBackupName()}' WITH DIFFERENTIAL, " +
                          $"MEDIANAME='{MsSqlConfigData.GetDatabaseName()}', " +
                          $"NAME = 'Differential backup of {MsSqlConfigData.GetDatabaseName()}'";
        }

        Console.WriteLine($"Backup started at: {DateTime.Now}");
        connection.RunQuery(backupQuery);
        Console.WriteLine($"Backup finished at: {DateTime.Now}");
    }
}