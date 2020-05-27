using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using NUnit.Framework;

namespace Dapper.Wrapper.Integration.Tests
{
    [TestFixture]
    public class QueryTests : TestBase
    {

        [Test]
        public async Task Query_Person_Async()
        {
            var repository = ServiceProvider.GetRequiredService<IRepository>();
            var persons = await repository.FindAsync(new QueryByTitleAsync("Mr."));
            Assert.That(persons, Is.Not.Empty);
        }

        [Test]
        public async Task Scalar_Person_Async()
        {
            var repository = ServiceProvider.GetRequiredService<IRepository>();
            var persons = await repository.FindAsync(new ScalarPersonAsync(1));
            Assert.That(persons, Is.Not.Null);
        }
    }

    public class ScalarPersonAsync : ScalarAsync<Person>
    {
        private string _sql = "select * from [Person].Person p where p.BusinessEntityId = @id";

        public ScalarPersonAsync(int id)
        {
            ContextQuery = async ctx =>
                               {
                                   var p = await ctx.QueryAsync<Person>(_sql, new {id});
                                   return p.FirstOrDefault();
                               };
        }
    }

    public class QueryByTitleAsync : QueryAsync<Person>
    {
        private string _sql = "select * from [Person].Person p where p.Title = @title";

        public QueryByTitleAsync(string title)
        {
            ContextQuery = ctx => ctx.QueryAsync<Person>(_sql, new {title});
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