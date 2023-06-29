using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using net_api_utils.Results;

namespace net_api_utils.Errores
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        public IActionResult ErrorLocalDevelopment([FromServices] ILogger<ErrorController> logger)
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>()!;

            logger.LogError(context.Error, "Ha ocurrido un error inesperado.");
            
            return new ResultUnexpected("Ha ocurrido un error inesperado.");
        }
    }
}
