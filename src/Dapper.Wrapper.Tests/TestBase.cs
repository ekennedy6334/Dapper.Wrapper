using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Moq;

using NUnit.Framework;

namespace Dapper.Wrapper.Tests
{
    public abstract class TestBase
    {
        public IServiceCollection ServiceCollection { get; private set; }

        public IServiceProvider ServiceProvider { get; private set; }

        public Mock<IRepository> RepositoryMock = new Mock<IRepository>();

        [SetUp]
        public void Setup()
        {
            ServiceCollection = new ServiceCollection();

            ServiceCollection.AddLogging(cfg => cfg.AddConsole())
                             .Configure<LoggerFilterOptions>(cfg => cfg.MinLevel = LogLevel.Error);

            ServiceCollection.AddTransient(provider => RepositoryMock.Object);

            Register();

            ServiceProvider = ServiceCollection.BuildServiceProvider();

            Initialize();
        }

        /// <summary>
        /// For implementations to do registration
        /// </summary>
        protected virtual void Register()
        {
            /* no-op */
        }

        /// <summary>
        /// For implementations to initialize from the provider
        /// Yeh.. 2 steps. Wonderful.
        /// </summary>
        protected virtual void Initialize()
        {
            /* no-op */
        }

        [TearDown]
        public void TearDown()
        {
            CleanUp();

            ServiceCollection?.Clear();

            ((IDisposable)ServiceProvider)?.Dispose();
        }

        protected virtual void CleanUp()
        {
            /* no-op */
        }
    }
}
