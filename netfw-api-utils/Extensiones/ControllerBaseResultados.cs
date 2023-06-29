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
        public static IHttpActionResult ResultValid(this ApiController controller, object datos)
        {
            return new ResultValid(datos);
        }

        public static IHttpActionResult ResultInvalid(this ApiController controller, string error)
        {
            return new ResultInvalid(error);
        }

        public static IHttpActionResult ResultInvalid(this ApiController controller, ModelStateDictionary modelState)
        {
            return new ResultInvalid(modelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage).ToList());
        }

        public static IHttpActionResult ResultUnexpected(this ApiController controller, string error)
        {
            return new ResultUnexpected(error);
        }

        public static bool Validate<T>(this ApiController controller, T modelo, out IHttpActionResult resultadoInvalido)
        {
            if (modelo == null)
            {
                modelo = (T) Activator.CreateInstance(typeof(T), new object[] { });

                controller.Validate(modelo);
            }

            if (!controller.ModelState.IsValid)
                resultadoInvalido = controller.ResultInvalid(controller.ModelState);
            else
                resultadoInvalido = null;

            return resultadoInvalido != null;
        }
    }
}
