using System;
using System.Threading.Tasks;

namespace Dapper.Wrapper
{
    /// <summary>
    ///     Base implementation of a query that returns a single value or object
    /// </summary>
    /// <typeparam name="T">The type of object or value being returned</typeparam>
    public class ScalarAsync<T> : QueryBase, IScalarAsync<T>
    {
        /// <summary>
        ///     The query to be executed later
        /// </summary>
        protected Func<IDbExecutor, Task<T>> ContextQuery { get; set; }

        #region IScalar<T> Members

        /// <summary>
        ///     Executes the expression against the passed in executor
        /// </summary>
        /// <param name="executor">The data executor that the scalar query is executed against</param>
        /// <returns>The instance of <typeparamref name="T" /> that the query materialized if any</returns>
        public async Task<T> ExecuteAsync(IDbExecutor executor)
        {
            Executor = executor;
            CheckExecutorAndQuery(ContextQuery);
            return await ContextQuery(executor);
        }

        #endregion


    }
}