using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace EProcurement.Infrastructure.DataBase
{
    public class DapperDbContext
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;
        private IDbConnection dbConnection;

        public DapperDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = configuration.GetConnectionString("SqlConnection");
        }

        public IDbConnection CreateConnection()
        {
            this.dbConnection = new SqlConnection(connectionString);
            return this.dbConnection;
        }
    }
}
