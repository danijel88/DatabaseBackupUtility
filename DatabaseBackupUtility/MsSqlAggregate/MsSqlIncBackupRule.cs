﻿using DatabaseBackupUtility.Helpers;

namespace DatabaseBackupUtility.MsSqlAggregate;

public class MsSqlIncBackupRule : DatabaseRule
{
    /// <inheritdoc />
    public override bool IsMatch(string dbProvider, string action, string? backupType)
    {
        if (string.IsNullOrEmpty(backupType)) throw new ArgumentNullException(nameof(backupType), "Backup Type type must be inserted.");
        return dbProvider.ToLower() == "mssql" && action.ToLower() == "backup" && backupType!.ToLower() == "inc";
    }

    /// <inheritdoc />
    public override async Task ExecuteAction(DatabaseProxy proxy)
    {
        DbSqlConnection connection = new DbSqlConnection();
        var result = await connection.TestConnection();
        string backupQuery = string.Empty;
        if (!result)
        {
            Console.WriteLine("Can not open connection to database.");
            return;
        }

        if (proxy.WithCompression.ToLower() == "y")
        {
            backupQuery = $"USE {MsSqlConfigData.GetDatabaseName()}; GO" +
                          $" BACKUP LOG {MsSqlConfigData.GetDatabaseName()} TO " +
                          $"DISK='{MsSqlConfigData.GetStorageLocation()}\\{MsSqlConfigData.GetBackupName()}' WITH COMPRESSION , " +
                          $"MEDIANAME='{MsSqlConfigData.GetDatabaseName()}', " +
                          $"NAME = 'Log-backup of {MsSqlConfigData.GetDatabaseName()}'";
        }
        else
        {
            backupQuery = $"USE {MsSqlConfigData.GetDatabaseName()}; GO" +
                          $" BACKUP LOG {MsSqlConfigData.GetDatabaseName()} TO " +
                          $"DISK='{MsSqlConfigData.GetStorageLocation()}\\{MsSqlConfigData.GetBackupName()}' WITH COMPRESSION , " +
                          $"MEDIANAME='{MsSqlConfigData.GetDatabaseName()}', " +
                          $"NAME = 'Log-backup of {MsSqlConfigData.GetDatabaseName()}'";
        }


        Console.WriteLine($"Backup started at: {DateTime.Now}");
        connection.RunQuery(backupQuery);
        Console.WriteLine($"Backup finished at: {DateTime.Now}");
    }
}