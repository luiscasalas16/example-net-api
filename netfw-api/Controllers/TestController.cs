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
        public IHttpActionResult TestA(TestADto parameters)
        {
            if (this.Validate(parameters, out IHttpActionResult resultado)) return resultado;

            return this.ResultValid(new TestAResultDto()
            {
                OutputMessage = $"{parameters.InputMessage} - A - {DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm-ss-fffff")}"
            });
        }

        [HttpPost]
        [ActionName("B")]
        public IHttpActionResult TestB(TestBDto parameters)
        {
            if (this.Validate(parameters, out IHttpActionResult resultado)) return resultado;

            return this.ResultValid(new TestBResultDto()
            {
                OutputMessage = $"{parameters.InputMessage} - B - {DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm-ss-fffff")}"
            });
        }
    }
}