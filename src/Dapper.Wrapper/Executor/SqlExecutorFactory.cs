using System;
using System.Data;
using System.Data.SqlClient;


// ReSharper disable once CheckNamespace
namespace Dapper.Wrapper
{
    public class SqlExecutorFactory : IDbExecutorFactory
    {
        readonly string _connectionString;

        public SqlExecutorFactory(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException(nameof(connectionString));
            _connectionString = connectionString;
        }

        public IDbExecutor CreateExecutor()
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            dbConnection.Open();
            return new SqlExecutor(dbConnection);
        }
    }
}
