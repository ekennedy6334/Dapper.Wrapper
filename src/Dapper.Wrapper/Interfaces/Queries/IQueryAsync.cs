using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Dapper.Wrapper
{
    public interface IQueryAsync<T> : IQueryBase
    {
        /// <summary>
        /// This executes the expression in ContextQuery on the executor that is passed in, resulting in an <see cref="IEnumerable{T}" />
        /// </summary>
        /// <param name="executor">the data executor that the query should be executed against</param>
        /// <returns>The collection of <typeparamref name="T" /> that the query materialized if any</returns>
        Task<IEnumerable<T>> ExecuteAsync(IDbExecutor executor);
    }
}