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
            return this.ResultValid(new { OutputMessage = $"0 - {DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm-ss-fffff")}" });
        }

        [HttpGet]
        public IActionResult GetA()
        {
            return this.ResultValid(new { OutputMessage = $"A - {DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm-ss-fffff")}" });
        }

        [HttpGet]
        public IActionResult GetB()
        {
            return this.ResultValid(new { OutputMessage = $"B - {DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm-ss-fffff")}" });
        }

        [HttpGet, ActionName("CGet")]
        public IActionResult GetC()
        {
            return this.ResultValid(new { OutputMessage = $"C - {DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm-ss-fffff")}" });
        }

        [HttpGet, ActionName("DGet")]
        public IActionResult GetD()
        {
            return this.ResultValid(new { OutputMessage = $"D - {DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm-ss-fffff")}" });
        }

        [HttpPost]
        public IActionResult Post(TestDto parameters)
        {
            return Test(parameters, "0");
        }

        [HttpPost]
        public IActionResult PostA(TestDto parameters)
        {
            return Test(parameters, "A");
        }

        [HttpPost]
        public IActionResult PostB(TestDto parameters)
        {
            return Test(parameters, "B");
        }

        [HttpPost, ActionName("CPost")]
        public IActionResult PostC(TestDto parameters)
        {
            return Test(parameters, "C");
        }

        [HttpPost, ActionName("DPost")]
        public IActionResult PostD(TestDto parameters)
        {
            return Test(parameters, "D");
        }

        private IActionResult Test(TestDto parameters, string id)
        {
            if (this.Validate(parameters, out IActionResult resultado)) return resultado;

            return this.ResultValid(new TestDtoResult()
            {
                OutputMessage = $"{parameters.InputMessage} - {id} - {DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm-ss-fffff")}"
            });
        }
    }
}