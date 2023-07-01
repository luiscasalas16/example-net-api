using System;
using System.Diagnostics;
using System.Web.Http;

namespace net_api.Controllers
{
    public class Test3Controller : ApiController
    {
        [HttpGet]
        [DebuggerStepThrough]
        public IHttpActionResult ErrorGet()
        {
            throw new ApplicationException("application error");
        }
    }
}
