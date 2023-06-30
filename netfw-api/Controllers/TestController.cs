using netfw_api.Models;
using netfw_api_utils.Extensions;
using System;
using System.Web.Http;

namespace netfw_api.Controllers
{
    public class TestController : ApiController
    {
        public TestController()
        {
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return this.ResultValid(true);
        }

        [HttpPost]
        public IHttpActionResult TestA(TestDto parameters)
        {
            return Test(parameters, "A");
        }

        [HttpPost]
        [ActionName("B")]
        public IHttpActionResult TestB(TestDto parameters)
        {
            return Test(parameters, "B");
        }

        private IHttpActionResult Test(TestDto parameters, string id)
        {
            if (this.Validate(parameters, out IHttpActionResult resultado)) return resultado;

            return this.ResultValid(new TestResultDto()
            {
                OutputMessage = $"{parameters.InputMessage} - {id} - {DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm-ss-fffff")}"
            });
        }
    }
}