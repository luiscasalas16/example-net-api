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
            return this.ResultValid(true);
        }

        [HttpPost]
        public IActionResult TestA([FromForm] TestDto parameters)
        {
            return Test(parameters, "A");
        }

        [HttpPost]
        public IActionResult TestB([FromForm] TestDto parameters)
        {
            return Test(parameters, "B");
        }

        [HttpPost, ActionName("C")]
        public IActionResult TestC([FromForm] TestDto parameters)
        {
            return Test(parameters, "C");
        }

        [HttpPost, ActionName("D")]
        public IActionResult TestD([FromForm] TestDto parameters)
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