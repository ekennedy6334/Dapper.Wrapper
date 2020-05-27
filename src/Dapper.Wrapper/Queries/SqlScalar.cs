using System;

// ReSharper disable once CheckNamespace
namespace Dapper.Wrapper
{
    public abstract class SqlScalar<T> : IScalar<T>
    {
        protected Func<IDbExecutor, T> ContextQuery;

        public T Execute(IDbExecutor executor)
        {
            return ContextQuery.Invoke(executor);
        }
    }
}
