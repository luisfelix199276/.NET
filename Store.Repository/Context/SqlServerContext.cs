using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Store.Repository.Context
{
    public class SqlServerContext
    {
        private const string CONNECTION_STRING_NAME = "DefaultConnection";

        private static string connectionString;
        private readonly IConfiguration _configuration;

        public interface IDatabaseConfig
        {
            string ConnectionString { get; }
        }

        public SqlServerContext(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = "Data Source=theURL.com; Initial Catalog=databaseName; User ID=UserName; Password=UserPassword;";
        }

        public class DatabaseConfig : IDatabaseConfig
        {
            public string ConnectionString
            {
                get { return connectionString; }
            }
        }

        public SqlConnection Context
        {
            get
            {
                var cn = new SqlConnection(connectionString);
                if (cn.State != System.Data.ConnectionState.Open)
                {
                    cn.Open();
                }
                return cn;
            }
        }
    }
}