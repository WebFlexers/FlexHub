using System.Data;
using System.Reflection;
using FlexHub.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FlexHub.Services.IntegrationTests.Fixtures;

public class LocalDbInitializerFixture : IDisposable
{
    private readonly string _dbName = "FlexHubIntegrationTests";

    public LocalDbInitializerFixture()
    {
        DeleteDB();
        CreateDB();
    }

    public void Dispose()
    {
        DeleteDB();
    }

    public ApplicationDbContext GetDbContextLocalDb(bool beginTransaction = true)
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer($"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog={_dbName};Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
            .Options;

        var context = new ApplicationDbContext(options);
        if (beginTransaction)
        {
            context.Database.BeginTransaction();
        }
        return context;
    }

    private void CreateDB()
    {
        ExecuteCommand(Master, $@"
        CREATE DATABASE [{_dbName}]
        ON (NAME = '{_dbName}',
        FILENAME = '{Filename}')");

        using (var context = GetDbContextLocalDb(beginTransaction: false))
        {
            context.Database.Migrate();
            // Good place to put test data
            context.SaveChanges();
        }
    }

    private void DeleteDB()
    {
        var fileNames = GetDbFiles(Master, $@"
        SELECT [physical_name] FROM [sys].[master_files]
        WHERE [database_id] = DB_ID('{_dbName}')");

        if (fileNames.Any())
        {
            ExecuteCommand(Master, $@"
            ALTER DATABASE [{_dbName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
            EXEC sp_detach_db '{_dbName}'");

            foreach (var filename in fileNames)
            {
                File.Delete(filename);
            }
        }
    }

    private void ExecuteCommand(string connectionString, string query)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            using (var cmd = new SqlCommand(query, connection))
            {
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }

    private IEnumerable<string> GetDbFiles(
        string connectionString,
        string query)
    {
        IEnumerable<string> files;
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (var cmd = new SqlCommand(query, connection))
            {
                using (var da = new SqlDataAdapter(cmd))
                {
                    var dt = new DataTable();
                    da.Fill(dt);
                    files = from DataRow myRow in dt.Rows
                            select (string)myRow["physical_name"];
                }
            }
        }
        return files;
    }

    private string Master =>
        new SqlConnectionStringBuilder
        {
            DataSource = @"(LocalDB)\MSSQLLocalDB",
            InitialCatalog = "master",
            IntegratedSecurity = true
        }.ConnectionString;

    private string Filename => Path.Combine(
        Path.GetDirectoryName(
            typeof(LocalDbInitializerFixture).GetTypeInfo().Assembly.Location)!,
        $"{_dbName}.mdf");
}