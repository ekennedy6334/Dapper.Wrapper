using System;

// ReSharper disable once CheckNamespace
namespace Dapper.Wrapper
{
    public interface IDbExecutorFactory
    {
        IDbExecutor CreateExecutor();
    }
}
