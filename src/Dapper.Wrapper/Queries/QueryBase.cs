using System;

// ReSharper disable once CheckNamespace
namespace Dapper.Wrapper
{
    /// <summary>
    ///     The base query that allows for appending expressions, query extensions, and eventing
    /// </summary>
    public abstract class QueryBase
    {
        /// <summary>
        ///     The reference to the <see cref="IDbExecutor" /> that wraps data connection
        /// </summary>
        protected IDbExecutor Executor { get; set; }

        /// <summary>
        ///     Checks the context and the Query for null
        /// </summary>
        /// <param name="query">The query to be executed</param>
        protected void CheckExecutorAndQuery(object query)
        {
            if (Executor == null)
            {
                throw new InvalidOperationException("Executor cannot be null.");
            }
            if (query == null)
            {
                throw new InvalidOperationException("Null Query cannot be executed.");
            }
        }
    }
}
