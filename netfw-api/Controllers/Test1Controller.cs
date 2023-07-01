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
            return GetResult("0");
        }

        [HttpGet]
        public IHttpActionResult GetA()
        {
            return GetResult("A");
        }

        [HttpGet]
        public IHttpActionResult GetB()
        {
            return GetResult("B");
        }

        [HttpGet, ActionName("CGet")]
        public IHttpActionResult GetC()
        {
            return GetResult("C");
        }

        [HttpGet, ActionName("DGet")]
        public IHttpActionResult GetD()
        {
            return GetResult("D");
        }

        private IHttpActionResult GetResult(string id)
        {
            return this.ResultValid(new { OutputMessage = $"{id} - {DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm-ss-fffff")}" });
        }

        [HttpPost]
        public IHttpActionResult Post(TestDto parameters)
        {
            return PostResult(parameters, "0");
        }

        [HttpPost]
        public IHttpActionResult PostA(TestDto parameters)
        {
            return PostResult(parameters, "A");
        }

        [HttpPost]
        public IHttpActionResult PostB(TestDto parameters)
        {
            return PostResult(parameters, "B");
        }

        [HttpPost, ActionName("CPost")]
        public IHttpActionResult PostC(TestDto parameters)
        {
            return PostResult(parameters, "C");
        }

        [HttpPost, ActionName("DPost")]
        public IHttpActionResult PostD(TestDto parameters)
        {
            return PostResult(parameters, "D");
        }

        private IHttpActionResult PostResult(TestDto parameters, string id)
        {
            if (this.Validate(parameters, out IHttpActionResult resultado)) return resultado;

            return this.ResultValid(new TestDtoResult()
            {
                OutputMessage = $"{parameters.InputMessage ?? ""} - {id} - {DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm-ss-fffff")}"
            });
        }
    }
}