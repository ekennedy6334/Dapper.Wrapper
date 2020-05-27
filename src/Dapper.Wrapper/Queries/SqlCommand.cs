using System;

// ReSharper disable once CheckNamespace
namespace Dapper.Wrapper
{
    public abstract class SqlCommand : ICommand
    {
        protected Func<IDbExecutor, int> ContextQuery;

        public int Execute(IDbExecutor executor)
        {
            return ContextQuery.Invoke(executor);
        }
    }
}
