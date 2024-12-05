using System.CommandLine;
using System.CommandLine.Invocation;
using DatabaseBackupUtility.Helpers;

namespace DatabaseBackupUtility
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var rootCommand = new RootCommand("Run command");
            var dbProvider = new Option<string>("--provider", "An DBMS provider");
            var dbAction = new Option<string>("--action", "An DBMS action, such as Backup,Restore");
            var backupType = new Option<string>("--backupType", "Backup type (Full, Inc, Diff)");
            var compression = new Option<string>("--compression", "Compress backup ");

            rootCommand.AddOption(dbProvider);
            rootCommand.AddOption(dbAction);
            rootCommand.AddOption(backupType);
            rootCommand.AddOption(compression);

            var engine = new DatabaseRuleEngine
                    .DatabaseBuilder()
                .FullBackupMsSqlDatabase()
                .DiffBackupMsSqlDatabase()
                .IncBackupMsSqlDatabase()
                .RestoreMsSqlDatabase()
                .Build();

            rootCommand.SetHandler((provider, action, type, compression) =>
            {
                // Validate and perform actions based on the arguments
                if (string.IsNullOrWhiteSpace(provider) || string.IsNullOrWhiteSpace(action))
                {
                    Console.WriteLine("Error: --provider and --action options are required.");
                    return;
                }
                var proxy = new DatabaseProxy(provider, action, type,compression);
                engine.ApplyRules(proxy);

            }, dbProvider, dbAction, backupType, compression);
            await rootCommand.InvokeAsync(args);
        }

    }
}
