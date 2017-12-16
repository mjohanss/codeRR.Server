using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using codeRR.Server.App.Core.Accounts;
using codeRR.Server.App.Core.Applications;
using codeRR.Server.App.Core.Users;
using codeRR.Server.Infrastructure.Configuration;
using codeRR.Server.ReportAnalyzer;
using codeRR.Server.ReportAnalyzer.Domain.Incidents;
using codeRR.Server.ReportAnalyzer.Domain.Reports;
using codeRR.Server.SqlServer.Analysis;
using codeRR.Server.SqlServer.Core.Accounts;
using codeRR.Server.SqlServer.Core.Applications;
using codeRR.Server.SqlServer.Core.Users;
using Coderr.Server.PluginApi.Config;
using Griffin.Data;
using Griffin.Data.Mapper;

namespace codeRR.Server.SqlServer.Tests
{
    public class TestTools : IDisposable
    {
        private string _dbName;

        public TestTools()
        {
            ConfigStore = new TestConfigStore();
            CanDropDatabase = true;
        }

        public ConfigurationStore ConfigStore { get; private set; }

        public bool CanDropDatabase { get; set; }

        public void Dispose()
        {
            if (_dbName == null)
                return;
            if (!CanDropDatabase)
            {
                Console.WriteLine("Do not delete " + _dbName);
                return;
            }

            using (var con = ConnectionFactory.OpenConnection())
            {
                var sql =
                    string.Format("alter database {0} set single_user with rollback immediate; DROP Database {0}",
                        _dbName);
                con.ExecuteNonQuery(sql);
            }
        }

        public void CreateBasicData()
        {
            using (var uow = CreateUnitOfWork())
            {
                CreateUserAndApplication(uow, out var accountId, out var applicationId);

                var report = new ErrorReportEntity(applicationId, Guid.NewGuid().ToString("N"), DateTime.UtcNow,
                    new ErrorReportException(new Exception("mofo")),
                    new List<ErrorReportContext> { new ErrorReportContext("Maps", new Dictionary<string, string>()) });
                report.Title = "Missing here";
                report.Init(report.GenerateHashCodeIdentifier());

                var incident = new IncidentBeingAnalyzed(report);
                var incRepos = new AnalyticsRepository(new AnalysisDbContext(uow), ConfigStore);
                incRepos.CreateIncident(incident);
                report.IncidentId = incident.Id;
                incRepos.CreateReport(report);

                uow.SaveChanges();
            }
        }

        public void CreateDatabase()
        {
            using (var con = ConnectionFactory.OpenConnection())
            {
                _dbName = "CdrTest" + Guid.NewGuid().ToString("N").Substring(0, 8);
                con.ExecuteNonQuery("CREATE Database " + _dbName);
                con.ChangeDatabase(_dbName);
                var schemaTool = new SchemaManager(() => con);
                schemaTool.CreateInitialStructure();
            }
        }

        public void CreateDatabase(string name, string path)
        {
            var dataFilename = Path.Combine(path, name + ".mdf");
            var logFilename = Path.Combine(path, name + ".log");

            using (var con = ConnectionFactory.OpenConnection())
            {
                var sql = $@"CREATE DATABASE [{name}]
        ON PRIMARY (
           NAME={name}_data,
           FILENAME = '{dataFilename}'
        )
        LOG ON (
            NAME={name}_log,
            FILENAME = '{logFilename}'
        )";

                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void CreateAndInitializeDatabase()
        {
            _dbName = $"coderrWebTest{DateTime.Now:yyyyMMddHHmmss}";
            var databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data");

            Environment.SetEnvironmentVariable("coderr_ConnectionString", @"Data Source=(LocalDB)\MSSQLLocalDB");

            CreateDatabase(_dbName, databasePath);

            Environment.SetEnvironmentVariable("coderr_ConnectionString", $@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog={_dbName};Integrated Security=True");

            var schemaManager = new SchemaManager(SqlServerTools.OpenConnection);
            schemaManager.CreateInitialStructure();
            schemaManager.UpgradeDatabaseSchema();

            InsertSettingsInfoDatabase();
        }

        public void InsertSettingsInfoDatabase()
        {
            using (var con = ConnectionFactory.OpenConnection())
            {
                var sql = @"INSERT INTO Settings (Section, Name, Value) VALUES
('BaseConfig', 'AllowRegistrations', 'False'), 
('BaseConfig', 'BaseUrl', 'http://localhost:50473/coderr/'), 
('BaseConfig', 'SenderEmail', 'webtests@coderr.com'), 
('BaseConfig', 'SupportEmail', 'webtests@coderr.com'), 
('ErrorTracking', 'ActivateTracking', 'True'), 
('ErrorTracking', 'ContactEmail', 'webtests@coderr.com'), 
('ErrorTracking', 'InstallationId', '068e0fc19e90460c86526693488289ee'), 
('SmtpSettings', 'AccountName', ''), 
('SmtpSettings', 'AccountPassword', ''), 
('SmtpSettings', 'SmtpHost', 'localhost'), 
('SmtpSettings', 'PortNumber', '25'), 
('SmtpSettings', 'UseSSL', 'False')
";
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IAdoNetUnitOfWork CreateUnitOfWork()
        {
            return new AdoNetUnitOfWork(OpenConnection(), false);
        }

        public void CreateUserAndApplication(out int accountId, out int applicationId)
        {
            using (var uow = CreateUnitOfWork())
            {
                CreateUserAndApplication(uow, out accountId, out applicationId);
                uow.SaveChanges();
            }
        }

        public IDbConnection OpenConnection()
        {
            var connection = ConnectionFactory.OpenConnection();
            connection.ChangeDatabase(_dbName);
            return connection;
        }

        public void ToLatestVersion()
        {
            var schemaTool = new SchemaManager(OpenConnection);
            schemaTool.UpgradeDatabaseSchema();
        }

        protected void CreateUserAndApplication(IAdoNetUnitOfWork uow, out int accountId, out int applicationId)
        {
            var accountRepos = new AccountRepository(uow);
            var account = new Account("arne", "123456") { Email = "arne@som.com" };
            accountRepos.Create(account);
            var userRepos = new UserRepository(uow);
            var user = new User(account.Id, "arne") { EmailAddress = "arne@som.com" };
            userRepos.CreateAsync(user).GetAwaiter().GetResult();

            var appRepos = new ApplicationRepository(uow);
            var app = new Application(account.Id, "MinApp");
            appRepos.CreateAsync(app).GetAwaiter().GetResult();
            var member = new ApplicationTeamMember(app.Id, account.Id, "Admin");
            appRepos.CreateAsync(member).GetAwaiter().GetResult();

            accountId = user.AccountId;
            applicationId = app.Id;
        }
    }
}