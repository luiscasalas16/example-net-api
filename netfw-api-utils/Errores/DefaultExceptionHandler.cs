using netfw_api_utils.Results;
using System.Web.Http.ExceptionHandling;

namespace netfw_api_utils.Errores
{
    public class DefaultExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            if (context.Exception is ErrorValidacion errorValidacion)
            {
                context.Result = new ResultInvalid(errorValidacion.Message);
                return;
            }
            else if (context.Exception is ErrorConfiguracion errorConfiguracion)
            {
                context.Result = new ResultInvalid(errorConfiguracion.Message);
                return;
            }
            else
            {
                context.Result = new ResultUnexpected("Ha ocurrido un error inesperado.", context.Exception.ToString());
            }
        }
    }
}
