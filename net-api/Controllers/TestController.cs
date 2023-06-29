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

        [HttpPost("A")]
        public IActionResult TestA([FromForm] TestADto parameters)
        {
            return this.ResultValid(new TestAResultDto()
            {
                OutputMessage = parameters.InputMessage
            });
        }

        [HttpPost("B")]
        public IActionResult TestB([FromForm] TestBDto parameters)
        {
            return this.ResultValid(new TestBResultDto()
            {
                OutputMessage = parameters.InputMessage
            });
        }
    }
}