using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Moq;

using NUnit.Framework;

namespace Dapper.Wrapper.Tests
{
    public class MockRepositoryTests : TestBase
    {
        protected override void Register()
        {
            ServiceCollection.AddTransient<IService, ServiceImpl>();
        }

        [Test]
        public void Using_Mock_Repo()
        {
            var p = new Person
                        {
                            FirstName = "Tom",
                            LastName = "Smith"
                        };

            RepositoryMock.Setup(x => x.Find(It.IsAny<FindPerson>())).Returns(p);

            var service = ServiceProvider.GetRequiredService<IService>();

            var s = service.Execute("some value");
            Assert.That(s, Is.EqualTo($"{p.FirstName} {p.LastName}"));
        }
    }

    public interface IService
    {
        string Execute(string value);
    }

    public class ServiceImpl : IService
    {
        private readonly IRepository _repository;
        private readonly ILogger<ServiceImpl> _logger;

        public ServiceImpl(IRepository repository, ILogger<ServiceImpl> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public string Execute(string value)
        {
            _logger.LogDebug($"Execute for {value}");
            var p = _repository.Find(new FindPerson(value));

            return $"{p.FirstName} {p.LastName}";
        }
    }

    // does nothing. Just need an implementation
    public class FindPerson : IScalar<Person>
    {
        public FindPerson(string value)
        {
            
        }

        public Person Execute(IDbExecutor executor)
        {
            return null;
        }
    }


    public class Person
    {
        public int BusinessEntityID { get; set; }

        public string PersonType { get; set; }

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Suffix { get; set; }

        public int EmailPromotion { get; set; }
    }
}