using Microsoft.AspNetCore.Mvc;
using net_api.Models;
using net_api_utils.Extensions;

namespace net_api.Controllers
{
    [ApiController, Route("[controller]/[action]")]
    public class Test1Controller : ControllerBase
    {
        private readonly ILogger<Test1Controller> _logger;
        private readonly IConfiguration _configuration;

        public Test1Controller(ILogger<Test1Controller> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

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
        public IActionResult Post([FromForm] TestDto parameters)
        {
            return Test(parameters, "0");
        }

        [HttpPost]
        public IActionResult PostA([FromForm] TestDto parameters)
        {
            return Test(parameters, "A");
        }

        [HttpPost]
        public IActionResult PostB([FromForm] TestDto parameters)
        {
            return Test(parameters, "B");
        }

        [HttpPost, ActionName("CPost")]
        public IActionResult PostC([FromForm] TestDto parameters)
        {
            return Test(parameters, "C");
        }

        [HttpPost, ActionName("DPost")]
        public IActionResult PostD([FromForm] TestDto parameters)
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