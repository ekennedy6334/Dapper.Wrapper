using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Dapper.Wrapper
{
    /// <summary>
    ///     An Interface for Queries that return collections
    /// </summary>
    /// <typeparam name="T">The Type being requested</typeparam>
    public interface IQuery<out T> : IQueryBase
    {
        /// <summary>
        ///     This executes the expression in ContextQuery on the executor that is passed in, resulting in
        ///      an <see cref="IEnumerable{T}" />
        /// </summary>
        /// <param name="executor">the data executor that the query should be executed against</param>
        /// <returns>The collection of <typeparamref name="T" /> that the query materialized if any</returns>
        IEnumerable<T> Execute(IDbExecutor executor);
    }
}