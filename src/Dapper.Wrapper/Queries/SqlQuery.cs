using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Dapper.Wrapper
{
    public class SqlQuery<T> : IQuery<T>
    {
        protected Func<IDbExecutor, IEnumerable<T>> ContextQuery;

        public string SqlStatement { get; set; }

        public IEnumerable<T> Execute(IDbExecutor executor)
        {
            return ContextQuery.Invoke(executor);
        }

        public string OutputQuery(IDbExecutor executor)
        {
            return SqlStatement;
        }
    }
}
