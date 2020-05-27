using System;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Dapper.Wrapper
{
    public abstract class SqlScalarAsync<T> : IScalarAsync<T>
    {
        protected Func<IDbExecutor, Task<T>> ContextQuery;

        public async Task<T> ExecuteAsync(IDbExecutor executor)
        {
            return await ContextQuery.Invoke(executor);
        }
    }
}