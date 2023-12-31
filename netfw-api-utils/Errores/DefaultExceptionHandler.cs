﻿using netfw_api_utils.Results;
using System.Web.Http.ExceptionHandling;

namespace netfw_api_utils.Errores
{
    // Implements default exception handler.

    public class DefaultExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            if (context.Exception is ValidationException errorValidacion)
            {
                context.Result = new ResultInvalid(context.Request, errorValidacion.Message);
                return;
            }
            else if (context.Exception is ConfigurationException errorConfiguracion)
            {
                context.Result = new ResultError(context.Request, errorConfiguracion.Message);
                return;
            }
            else
            {
                context.Result = new ResultError(context.Request, "internal api error", context.Exception.Message);
            }
        }
    }
}
