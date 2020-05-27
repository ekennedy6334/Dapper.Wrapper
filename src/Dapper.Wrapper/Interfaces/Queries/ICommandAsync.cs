using System;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Dapper.Wrapper
{
    /// <summary>
    ///     An Interface for Command Queries that return no value, or the return is ignored
    /// </summary>
    public interface ICommandAsync
    {
        /// <summary>
        ///     Executes the expression against the passed in context and ignores the returned value if any
        /// </summary>
        /// <param name="executor">The sql for the command</param>
        Task<int> ExecuteAsync(IDbExecutor executor);
    }
}