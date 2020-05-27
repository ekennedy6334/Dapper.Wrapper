using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;


// ReSharper disable once CheckNamespace
namespace Dapper.Wrapper
{
    public class SqlExecutor : IDbExecutor
    {
        public SqlExecutor(IDbConnection dbConnection)
        {
            Connection = dbConnection;
        }

        public int Execute(
            string sql,
            object param = null,
            IDbTransaction transaction = null,
            int? commandTimeout = default,
            CommandType? commandType = default)
        {
            return Connection.Execute(
                                      sql,
                                      param,
                                      transaction,
                                      commandTimeout,
                                      commandType);
        }

        public async Task<int> ExecuteAsync(
            string sql,
            object param = null,
            IDbTransaction transaction = null,
            int? commandTimeout = default,
            CommandType? commandType = default)
        {
            return await Connection.ExecuteAsync(
                                      sql,
                                      param,
                                      transaction,
                                      commandTimeout,
                                      commandType);
        }

        public IEnumerable<dynamic> Query(
            string sql,
            object param = null,
            IDbTransaction transaction = null,
            bool buffered = true,
            int? commandTimeout = default,
            CommandType? commandType = default)
        {
            return Connection.Query(
                                    sql,
                                    param,
                                    transaction,
                                    buffered,
                                    commandTimeout,
                                    commandType);
        }

        public async Task<IEnumerable<dynamic>> QueryAsync(
            string sql,
            object param = null,
            IDbTransaction transaction = null,
            int? commandTimeout = default,
            CommandType? commandType = default)
        {
            return await Connection.QueryAsync(sql,
                                    param,
                                    transaction,
                                    commandTimeout,
                                    commandType);
        }

        public IEnumerable<T> Query<T>(
            string sql,
            object param = null,
            IDbTransaction transaction = null,
            bool buffered = true,
            int? commandTimeout = default,
            CommandType? commandType = default)
        {
            return Connection.Query<T>(
                                       sql,
                                       param,
                                       transaction,
                                       buffered,
                                       commandTimeout,
                                       commandType);
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(
            string sql,
            object param = null,
            IDbTransaction transaction = null,
            int? commandTimeout = default,
            CommandType? commandType = default)
        {
            return await Connection.QueryAsync<T>(
                                       sql,
                                       param,
                                       transaction,
                                       commandTimeout,
                                       commandType);
        }

        public IDbConnection Connection { get; }

        public void Dispose()
        {
            Connection.Dispose();
        }
    }
}