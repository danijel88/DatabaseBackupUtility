using System.Data;
using Microsoft.Data.SqlClient;

namespace DatabaseBackupUtility.Helpers;

public class DbSqlConnection
{
    public void RunQuery(string query)
    {
        var connectionString = GetConnectionString();
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }

    public async Task<bool> TestConnection()
    {
        var connectionString = GetConnectionString();
        SqlConnection connection = new SqlConnection(connectionString);
        try
        {
            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }

    }

    private static string GetConnectionString()
    {
        var connectionString = $"Server={MsSqlConfigData.GetServer()},{MsSqlConfigData.GetPort()};Database={MsSqlConfigData.GetDatabaseName()};user id={MsSqlConfigData.GetUserId()};password={MsSqlConfigData.GetPassword()};TrustServerCertificate=true";
        return connectionString;
    }
}