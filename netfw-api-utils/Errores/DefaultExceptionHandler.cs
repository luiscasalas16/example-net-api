using System;
using System.IO;
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
                //try
                //{
                //    string archivo = Path.Combine(ConfigurationManager.AppSettings["RutaArchivos"], DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm-ss-fffff") + ".err");

                //    AyudanteArchivos.Escribir(archivo, context.Exception.ToString());
                //}
                //catch (Exception)
                //{
                //    //ignore
                //}

                context.Result = new ResultUnexpected("Ha ocurrido un error inesperado.", context.Exception.ToString());
            }
        }
    }
}
