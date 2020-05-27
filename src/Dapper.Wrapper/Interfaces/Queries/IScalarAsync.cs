using System;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Dapper.Wrapper
{
    /// <summary>
    ///     An Interface for Scalar Queries that return a single value or object
    /// </summary>
    /// <typeparam name="T">The Type that is being returned</typeparam>
    public interface IScalarAsync<T>
    {
        /// <summary>
        ///     Executes the expression against the passed in executor
        /// </summary>
        /// <param name="executor">The data executor that the scalar query is executed against</param>
        /// <returns>The instance of <typeparamref name="T" /> that the query materialized if any</returns>
        Task<T> ExecuteAsync(IDbExecutor executor);
    }
}