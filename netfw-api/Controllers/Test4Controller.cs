using System;
using System.Diagnostics;
using System.Web.Http;

namespace netfw_api.Controllers
{
    public class Test4Controller : ApiController
    {
        [HttpGet]
        [DebuggerStepThrough]
        public IHttpActionResult ErrorGet()
        {
            throw new ApplicationException("application error");
        }
    }
}
