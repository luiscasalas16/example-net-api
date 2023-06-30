using Microsoft.AspNetCore.Mvc;
using net_api.Models;
using net_api_utils.Extensions;

namespace net_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private readonly IConfiguration _configuration;

        public TestController(ILogger<TestController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return this.ResultValid(true);
        }

        [HttpPost("TestA")]
        public IActionResult TestA([FromForm] TestDto parameters)
        {
            return Test(parameters, "A");
        }

        [HttpPost("TestB")]
        public IActionResult TestB([FromForm] TestDto parameters)
        {
            return Test(parameters, "B");
        }

        [HttpPost("C")]
        public IActionResult TestC([FromForm] TestDto parameters)
        {
            return Test(parameters, "C");
        }

        [HttpPost("D")]
        public IActionResult TestD([FromForm] TestDto parameters)
        {
            return Test(parameters, "D");
        }

        private IActionResult Test(TestDto parameters, string id)
        {
            if (this.Validate(parameters, out IActionResult resultado)) return resultado;

            return this.ResultValid(new TestResultDto()
            {
                OutputMessage = $"{parameters.InputMessage} - {id} - {DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm-ss-fffff")}"
            });
        }
    }
}