using Microsoft.AspNetCore.Mvc;
using net_api.Models;
using net_api_utils.Extensions;

namespace net_api.Controllers
{
    [ApiController, Route("[controller]/[action]")]
    public class Test1Controller : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return GetResult("0");
        }

        [HttpGet]
        public IActionResult GetA()
        {
            return GetResult("A");
        }

        [HttpGet]
        public IActionResult GetB()
        {
            return GetResult("B");
        }

        [HttpGet, ActionName("CGet")]
        public IActionResult GetC()
        {
            return GetResult("C");
        }

        [HttpGet, ActionName("DGet")]
        public IActionResult GetD()
        {
            return GetResult("D");
        }

        private IActionResult GetResult(string id)
        {
            return this.ResultValid(new { OutputMessage = $"{id} - {DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm-ss-fffff")}" });
        }

        [HttpPost]
        public IActionResult Post(TestDto parameters)
        {
            return PostResult(parameters, "0");
        }

        [HttpPost]
        public IActionResult PostA(TestDto parameters)
        {
            return PostResult(parameters, "A");
        }

        [HttpPost]
        public IActionResult PostB(TestDto parameters)
        {
            return PostResult(parameters, "B");
        }

        [HttpPost, ActionName("CPost")]
        public IActionResult PostC(TestDto parameters)
        {
            return PostResult(parameters, "C");
        }

        [HttpPost, ActionName("DPost")]
        public IActionResult PostD(TestDto parameters)
        {
            return PostResult(parameters, "D");
        }

        private IActionResult PostResult(TestDto parameters, string id)
        {
            if (this.Validate(parameters, out IActionResult resultado)) return resultado;

            return this.ResultValid(new TestDtoResult()
            {
                OutputMessage = $"{parameters.InputMessage} - {id} - {DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm-ss-fffff")}"
            });
        }
    }
}