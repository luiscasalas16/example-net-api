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
        public bool Get()
        {
            return true;
        }

        [HttpPost("TestA")]
        public IActionResult TestA([FromForm] TestADto parameters)
        {
            if (this.Validate(parameters, out IActionResult resultado)) return resultado;

            return this.ResultValid(new TestAResultDto()
            {
                OutputMessage = $"{parameters.InputMessage} - A - {DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm-ss-fffff")}"
            });
        }

        [HttpPost("B")]
        public IActionResult TestB([FromForm] TestBDto parameters)
        {
            if (this.Validate(parameters, out IActionResult resultado)) return resultado;

            return this.ResultValid(new TestBResultDto()
            {
                OutputMessage = $"{parameters.InputMessage} - B - {DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm-ss-fffff")}"
            });
        }
    }
}