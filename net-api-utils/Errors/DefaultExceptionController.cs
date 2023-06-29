using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using net_api_utils.Results;

namespace net_api_utils.Errores
{
    [ApiController]
    public class DefaultExceptionController : ControllerBase
    {
        [Route("/error")]
        public IActionResult ErrorLocalDevelopment([FromServices] ILogger<DefaultExceptionController> logger)
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>()!;

            logger.LogError(context.Error, "Unexpected error.");

            if (context.Error is ValidationException errorValidacion)
            {
                return new ResultInvalid(errorValidacion.Message);
            }
            else if (context.Error is ConfigurationException errorConfiguracion)
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
