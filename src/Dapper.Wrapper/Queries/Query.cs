using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Dapper.Wrapper
{
    /// <summary>
    ///     The base implementation for Queries that return collections
    /// </summary>
    /// <typeparam name="T">The Type being requested</typeparam>
    public class Query<T> : QueryBase, IQuery<T>
    {
        /// <summary>
        ///     This holds the expression that will be used to create the <see cref="IEnumerable{T}" /> when executed on the executor
        /// </summary>
        protected Func<IDbExecutor, IEnumerable<T>> ContextQuery { get; set; }

        /// <summary>
        ///     This method allows for the extension of Ordering and Grouping on the prebuilt Query
        /// </summary>
        /// <returns>an <see cref="IQueryable{T}" /></returns>
        protected virtual IEnumerable<T> ExtendQuery()
        {
            return ContextQuery(Executor);
        }

        private IEnumerable<T> PrepareQuery(IDbExecutor executor)
        {
            Executor = executor;
            CheckExecutorAndQuery(ContextQuery);
            return ExtendQuery();
        }

        #region IQuery<T> Members

        /// <summary>
        ///     This executes the expression in ContextQuery on the executor that is passed in, resulting in an <see cref="IEnumerable{T}" />
        /// </summary>
        /// <param name="executor">the data executor that the query should be executed against</param>
        /// <returns>
        ///     <see cref="IEnumerable{T}" />
        /// </returns>
        public virtual IEnumerable<T> Execute(IDbExecutor executor)
        {
            var task = PrepareQuery(executor);
            return task;
        }


        #endregion
    }
}
