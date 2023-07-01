using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace net_api.Controllers
{
    [ApiController, Route("[controller]/[action]")]
    public class Test4Controller : ControllerBase
    {
        [HttpGet]
        [DebuggerStepThrough]
        public IActionResult ErrorGet()
        {
            throw new ApplicationException("application error");
        }
    }
}
