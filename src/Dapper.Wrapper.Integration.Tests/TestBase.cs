using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using NUnit.Framework;

namespace Dapper.Wrapper.Integration.Tests
{
    public abstract class TestBase
    {
        public IServiceCollection ServiceCollection { get; private set; }

        public IServiceProvider ServiceProvider { get; private set; }

        [SetUp]
        public void Setup()
        {
            var builder = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile("local.settings.json", optional: false)
                         .AddEnvironmentVariables();

            var configuration = builder.Build();

            var connectionString = configuration.GetConnectionString("AdventureWorks2019ConnectionString");

            ServiceCollection = new ServiceCollection();

            ServiceCollection.AddLogging(cfg => cfg.AddConsole())
                             .Configure<LoggerFilterOptions>(cfg => cfg.MinLevel = LogLevel.Error);

            ServiceCollection.AddTransient(provider => RepositoryFactory.Create(connectionString));

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
