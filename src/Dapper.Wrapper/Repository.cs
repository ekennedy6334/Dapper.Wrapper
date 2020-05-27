using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dapper.Wrapper
{
    /// <summary>
    ///     A repository implementation that uses Specification pattern to execute Queries in a
    ///     controlled fashion.
    /// Implements the <see cref="Dapper.Wrapper.IRepository" />
    /// </summary>
    /// <seealso cref="Dapper.Wrapper.IRepository" />
    public class Repository : IRepository
    {
        /// <summary>
        ///     Creates a Repository that uses the executor provided
        /// </summary>
        /// <param name="executor">The data executor that this repository uses</param>
        public Repository(IDbExecutor executor)
        {
            Executor = executor;
        }

        /// <summary>
        ///     Reference to the DataContext the repository is using
        /// </summary>
        public IDbExecutor Executor { get; }

        /// <summary>
        ///     Executes a prebuilt <see cref="IQuery{T}" /> and returns an <see cref="IEnumerable{T}" />
        /// </summary>
        /// <typeparam name="T">The Entity being queried</typeparam>
        /// <param name="query">The prebuilt Query Object</param>
        /// <returns>The <see cref="IEnumerable{T}" /> returned from the query</returns>
        public virtual IEnumerable<T> Find<T>(IQuery<T> query)
        {
            return query.Execute(Executor);
        }

        /// <summary>
        /// Executes a prebuilt <see cref="IQueryAsync{T}" /> and returns an <see cref="IEnumerable{T}" />
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryAsync">The query asynchronous.</param>
        /// <returns>Task&lt;IEnumerable&lt;T&gt;&gt;.</returns>
        public virtual async Task<IEnumerable<T>> FindAsync<T>(IQueryAsync<T> queryAsync)
        {
            return await queryAsync.ExecuteAsync(Executor);
        }

        /// <summary>
        ///     Executes a prebuilt <see cref="IScalar{T}" /> and returns a single instance of <typeparamref name="T" />
        /// </summary>
        /// <typeparam name="T">The Entity being queried</typeparam>
        /// <param name="query">The prebuilt Query Object</param>
        /// <returns>The instance of <typeparamref name="T" /> returned from the query</returns>
        public virtual T Find<T>(IScalar<T> query)
        {
            return query.Execute(Executor);
        }

        /// <summary>
        /// Executes a prebuilt <see cref="IScalarAsync{T}" /> and returns a single instance of <typeparamref name="T" />
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query">The query.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public virtual async Task<T> FindAsync<T>(IScalarAsync<T> query)
        {
            return await query.ExecuteAsync(Executor);
        }

        /// <summary>
        /// Executes a prebuilt <see cref="ICommand" />
        /// </summary>
        /// <param name="command">The prebuilt command object</param>
        /// <returns>System.Int32.</returns>
        public virtual int Execute(ICommand command)
        {
            return command.Execute(Executor);
        }

        /// <summary>
        /// Executes a prebuilt <see cref="ICommandAsync" />
        /// </summary>
        /// <param name="commandAsync">The command asynchronous.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public virtual async Task<int> ExecuteAsync(ICommandAsync commandAsync)
        {
            return await commandAsync.ExecuteAsync(Executor);
        }

        public void Dispose()
        {
            Executor?.Dispose();
        }
    }
}
