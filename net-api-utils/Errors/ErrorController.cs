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

            logger.LogError(context.Error, "Unexpected error.");

            if (context.Error is ErrorValidacion errorValidacion)
            {
                return new ResultInvalid(errorValidacion.Message);
            }
            else if (context.Error is ErrorConfiguracion errorConfiguracion)
            {
                return new ResultInvalid(errorConfiguracion.Message);
            }
            else
            {
                return new ResultUnexpected("Unexpected error.", context.Error.ToString());
            }
        }
    }
}
