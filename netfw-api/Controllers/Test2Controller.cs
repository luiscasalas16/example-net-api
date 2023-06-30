using Bogus;
using netfw_api.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace netfw_api.Controllers
{
    public class Test2Controller : ApiController
    {
        public IEnumerable<TestEntityDto> Get()
        {
            var result = new Faker<TestEntityDto>()
                .RuleFor(o => o.Id, f => f.Random.Int(1, 100))
                .RuleFor(o => o.FistName, f => f.Name.FirstName())
                .RuleFor(o => o.LastName, f => f.Name.LastName())
                .RuleFor(o => o.Email, f => f.Internet.Email());
            
            return result.Generate(2);
        }

        public TestEntityDto Get(int id)
        {
            var result = new Faker<TestEntityDto>()
                .RuleFor(o => o.Id, id)
                .RuleFor(o => o.FistName, f => f.Name.FirstName())
                .RuleFor(o => o.LastName, f => f.Name.LastName())
                .RuleFor(o => o.Email, f => f.Internet.Email());

            return result.Generate(1)[0];
        }

        public TestEntityDto Post([FromBody] TestEntityDto value)
        {
            value.Id = new Faker().Random.Int(1, 100);

            return value;
        }

        public void Put(int id, [FromBody] string value)
        {
        }

        public void Delete(int id)
        {
        }
    }
}
