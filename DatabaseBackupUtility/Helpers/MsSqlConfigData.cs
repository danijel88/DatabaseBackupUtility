using System.Text.Json;
using DatabaseBackupUtility.Core;

namespace DatabaseBackupUtility.Helpers;

public static class MsSqlConfigData
{
    public static string GetDatabaseName()
    {
        string jsonString = File.ReadAllText("DbConfig\\MsSqlConfig.json");
        DbConfig? config = JsonSerializer.Deserialize<DbConfig>(jsonString);
        return config!.Database;
    }
    public static string GetServer()
    {
        string jsonString = File.ReadAllText("DbConfig\\MsSqlConfig.json");
        DbConfig? config = JsonSerializer.Deserialize<DbConfig>(jsonString);
        return config!.Server;
    }
    public static string GetUserId()
    {
        string jsonString = File.ReadAllText("DbConfig\\MsSqlConfig.json");
        DbConfig? config = JsonSerializer.Deserialize<DbConfig>(jsonString);
        return config!.UserId;
    }
    public static string GetPassword()
    {
        string jsonString = File.ReadAllText("DbConfig\\MsSqlConfig.json");
        DbConfig? config = JsonSerializer.Deserialize<DbConfig>(jsonString);
        return config!.Password;
    }
    public static string GetPort()
    {
        string jsonString = File.ReadAllText("DbConfig\\MsSqlConfig.json");
        DbConfig? config = JsonSerializer.Deserialize<DbConfig>(jsonString);
        return config!.Port;
    }
    public static string GetStorageLocation()
    {
        string jsonString = File.ReadAllText("DbConfig\\MsSqlConfig.json");
        DbConfig? config = JsonSerializer.Deserialize<DbConfig>(jsonString);
        return config!.StorageLocation;
    }
    public static string GetBackupName()
    {
        string jsonString = File.ReadAllText("DbConfig\\MsSqlConfig.json");
        DbConfig? config = JsonSerializer.Deserialize<DbConfig>(jsonString);
        return config!.BackupName;
    }
    public static string GetRestoreDbName()
    {
        string jsonString = File.ReadAllText("DbConfig\\MsSqlConfig.json");
        DbConfig? config = JsonSerializer.Deserialize<DbConfig>(jsonString);
        return config!.RestoreDbName;
    }
    public static string GetRestoreMdfPath()
    {
        string jsonString = File.ReadAllText("DbConfig\\MsSqlConfig.json");
        DbConfig? config = JsonSerializer.Deserialize<DbConfig>(jsonString);
        return config!.RestoreMdfPath;
    }
    public static string GetRestoreLdfPath()
    {
        string jsonString = File.ReadAllText("DbConfig\\MsSqlConfig.json");
        DbConfig? config = JsonSerializer.Deserialize<DbConfig>(jsonString);
        return config!.RestoreLdfPath;
    }

    
}