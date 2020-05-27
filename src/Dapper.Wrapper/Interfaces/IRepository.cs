using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Dapper.Wrapper
{
    /// <summary>
    ///     The interface used to interact with the ORM Specific Implementations
    /// </summary>
    public interface IRepository : IDisposable
    {
        /// <summary>
        ///     Reference to the IDbExecutor the repository, allowing for create, update, and delete
        /// </summary>
        IDbExecutor Executor { get; }

        /// <summary>
        ///     Executes a prebuilt <see cref="IQuery{T}" /> and returns an <see cref="IEnumerable{T}" />
        /// </summary>
        /// <typeparam name="T">The Entity being queried</typeparam>
        /// <param name="query">The prebuilt Query Object</param>
        /// <returns>The <see cref="IEnumerable{T}" /> returned from the query</returns>
        IEnumerable<T> Find<T>(IQuery<T> query);

        /// <summary>
        /// Executes a prebuilt <see cref="IQueryAsync{T}" /> and returns an <see cref="IEnumerable{T}" />
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryAsync">The query asynchronous.</param>
        /// <returns>Task&lt;IEnumerable&lt;T&gt;&gt;.</returns>
        Task<IEnumerable<T>> FindAsync<T>(IQueryAsync<T> queryAsync);

        /// <summary>
        ///     Executes a prebuilt <see cref="IScalar{T}" /> and returns a single instance of <typeparamref name="T" />
        /// </summary>
        /// <typeparam name="T">The Entity being queried</typeparam>
        /// <param name="query">The prebuilt Query Object</param>
        /// <returns>The instance of <typeparamref name="T" /> returned from the query</returns>
        T Find<T>(IScalar<T> query);

        /// <summary>
        /// Executes a prebuilt <see cref="IScalarAsync{T}" /> and returns a single instance of <typeparamref name="T" />
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query">The query.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        Task<T> FindAsync<T>(IScalarAsync<T> query);

        /// <summary>
        ///     Executes a prebuilt <see cref="ICommand" />
        /// </summary>
        /// <param name="command">The prebuilt command object</param>
        int Execute(ICommand command);

        /// <summary>
        /// Executes a prebuilt <see cref="ICommandAsync" />
        /// </summary>
        /// <param name="commandAsync">The command asynchronous.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        Task<int> ExecuteAsync(ICommandAsync commandAsync);
    }
}
