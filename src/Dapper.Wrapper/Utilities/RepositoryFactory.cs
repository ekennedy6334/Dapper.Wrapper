using System;


// ReSharper disable once CheckNamespace
namespace Dapper.Wrapper
{
    public static class RepositoryFactory
    {
        public static Func<string, IRepository> Create = connectionString =>
                                                             {
                                                                 var sqlExecutor = new SqlExecutorFactory(connectionString);
                                                                 return new Repository(sqlExecutor.CreateExecutor());
                                                             };
    }
}
