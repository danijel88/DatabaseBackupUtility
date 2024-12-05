using DatabaseBackupUtility.MsSqlAggregate;

namespace DatabaseBackupUtility;

public class DatabaseRuleEngine(IList<DatabaseRule> rules)
{
    public void ApplyRules(DatabaseProxy proxy)
    {
        foreach (var rule in rules)
        {
            if (rule.IsMatch(proxy.DbProvider,proxy.Action, proxy.BackupType))
            {
                rule.ExecuteAction(proxy);
            }
        }
    }
    public class DatabaseBuilder
    {
        private readonly IList<DatabaseRule> _rules = new List<DatabaseRule>();

        public DatabaseBuilder FullBackupMsSqlDatabase()
        {
            _rules.Add(new MsSqlFullBackupRule());
            return this;
        }

        public DatabaseBuilder DiffBackupMsSqlDatabase()
        {
            _rules.Add(new MsSqlDiffBackupRule());
            return this;
        }
        public DatabaseBuilder IncBackupMsSqlDatabase()
        {
            _rules.Add(new MsSqlIncBackupRule());
            return this;
        }

        public DatabaseBuilder RestoreMsSqlDatabase()
        {
            _rules.Add(new MsSqlRestoreRule());
            return this;
        }

        public DatabaseRuleEngine Build()
        {
            return new DatabaseRuleEngine(_rules);
        }
    }
}