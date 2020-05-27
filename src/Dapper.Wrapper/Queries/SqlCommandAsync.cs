using System;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Dapper.Wrapper
{
    public abstract class SqlCommandAsync : ICommandAsync
    {
        protected Func<IDbExecutor, Task<int>> ContextQuery;

        public async Task<int> ExecuteAsync(IDbExecutor executor)
        {
            return await ContextQuery.Invoke(executor);
        }
    }
}