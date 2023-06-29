using netfw_api_utils.Results;
using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.Results;

namespace netfw_api_utils.Extensiones
{
    public static class ControllerBaseResultados
    {
        public static IHttpActionResult ResultadoValido(this ApiController controller, object datos)
        {
            return new ResultadoValido(datos);
        }

        public static IHttpActionResult ResultadoInvalido(this ApiController controller, string error)
        {
            return new ResultadoInvalido(error);
        }

        public static IHttpActionResult ResultadoInvalido(this ApiController controller, ModelStateDictionary modelState)
        {
            return new ResultadoInvalido(modelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage).ToList());
        }

        public static IHttpActionResult ResultadoInesperado(this ApiController controller, string error)
        {
            return new ResultadoInesperado(error);
        }

        public static IHttpActionResult ResultadoArchivo(this ApiController controller, byte[] archivo)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK) { Content = new ByteArrayContent(archivo) };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            return new ResponseMessageResult(response);
        }

        public static bool Validar<T>(this ApiController controller, T modelo, out IHttpActionResult resultadoInvalido)
        {
            if (modelo == null)
            {
                modelo = (T) Activator.CreateInstance(typeof(T), new object[] { });

                controller.Validate(modelo);
            }

            if (!controller.ModelState.IsValid)
                resultadoInvalido = controller.ResultadoInvalido(controller.ModelState);
            else
                resultadoInvalido = null;

            return resultadoInvalido != null;
        }
    }
}
