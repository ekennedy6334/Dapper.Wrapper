using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Dapper.Wrapper
{
    public class SqlQueryAsync<T> : IQueryAsync<T>
    {
        protected Func<IDbExecutor, Task<IEnumerable<T>>> ContextQuery;

        public string SqlStatement { get; set; }

        public async Task<IEnumerable<T>> ExecuteAsync(IDbExecutor executor)
        {
            return await ContextQuery.Invoke(executor);
        }

        public string OutputQuery(IDbExecutor executor)
        {
            return SqlStatement;
        }
    }
}