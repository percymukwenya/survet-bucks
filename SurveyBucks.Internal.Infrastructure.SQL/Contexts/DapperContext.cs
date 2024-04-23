using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SurveyBucks.Internal.Infrastructure.SQL.Contexts
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DapperConnection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
