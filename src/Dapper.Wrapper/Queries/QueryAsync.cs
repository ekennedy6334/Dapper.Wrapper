using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// ReSharper disable once CheckNamespace
namespace Dapper.Wrapper
{
    /// <summary>
    ///     The base implementation for Queries that return collections
    /// </summary>
    /// <typeparam name="T">The Type being requested</typeparam>
    public class QueryAsync<T> : QueryBase, IQueryAsync<T>
    {
        /// <summary>
        ///     This holds the expression that will be used to create the <see cref="IEnumerable{T}" /> when executed on the executor
        /// </summary>
        protected Func<IDbExecutor, Task<IEnumerable<T>>> ContextQuery { get; set; }

        /// <summary>
        ///     This method allows for the extension of Ordering and Grouping on the prebuilt Query
        /// </summary>
        /// <returns>an <see cref="IQueryable{T}" /></returns>
        protected virtual async Task<IEnumerable<T>> ExtendQuery()
        {
            return await ContextQuery(Executor);
        }

        private async Task<IEnumerable<T>> PrepareQuery(IDbExecutor executor)
        {
            Executor = executor;
            CheckExecutorAndQuery(ContextQuery);
            return await ExtendQuery();
        }

        #region IQuery<T> Members

        /// <summary>
        ///     This executes the expression in ContextQuery on the executor that is passed in, resulting in an <see cref="IEnumerable{T}" />
        /// </summary>
        /// <param name="executor">the data executor that the query should be executed against</param>
        /// <returns>
        ///     <see cref="IEnumerable{T}" />
        /// </returns>
        public async Task<IEnumerable<T>> ExecuteAsync(IDbExecutor executor)
        {
            var task = await PrepareQuery(executor);
            return task;
        }

        #endregion

    }
}