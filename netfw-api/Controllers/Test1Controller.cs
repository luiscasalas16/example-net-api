using netfw_api.Models;
using netfw_api_utils.Extensions;
using System;
using System.Web.Http;

namespace netfw_api.Controllers
{
    public class Test1Controller : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            return this.ResultValid(new { OutputMessage = $"0 - {DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm-ss-fffff")}" });
        }

        [HttpGet]
        public IHttpActionResult GetA()
        {
            return this.ResultValid(new { OutputMessage = $"A - {DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm-ss-fffff")}" });
        }

        [HttpGet]
        public IHttpActionResult GetB()
        {
            return this.ResultValid(new { OutputMessage = $"B - {DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm-ss-fffff")}" });
        }

        [HttpGet, ActionName("CGet")]
        public IHttpActionResult GetC()
        {
            return this.ResultValid(new { OutputMessage = $"C - {DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm-ss-fffff")}" });
        }

        [HttpGet, ActionName("DGet")]
        public IHttpActionResult GetD()
        {
            return this.ResultValid(new { OutputMessage = $"D - {DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm-ss-fffff")}" });
        }

        [HttpPost]
        public IHttpActionResult Post(TestDto parameters)
        {
            return Test(parameters, "0");
        }

        [HttpPost]
        public IHttpActionResult PostA(TestDto parameters)
        {
            return Test(parameters, "A");
        }

        [HttpPost]
        public IHttpActionResult PostB(TestDto parameters)
        {
            return Test(parameters, "B");
        }

        [HttpPost, ActionName("CPost")]
        public IHttpActionResult PostC(TestDto parameters)
        {
            return Test(parameters, "C");
        }

        [HttpPost, ActionName("DPost")]
        public IHttpActionResult PostD(TestDto parameters)
        {
            return Test(parameters, "D");
        }

        private IHttpActionResult Test(TestDto parameters, string id)
        {
            if (this.Validate(parameters, out IHttpActionResult resultado)) return resultado;

            return this.ResultValid(new TestDtoResult()
            {
                OutputMessage = $"{parameters.InputMessage ?? ""} - {id} - {DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm-ss-fffff")}"
            });
        }
    }
}