using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using net_api_utils.Results;

namespace net_api_utils.Extensions
{
    public static class ControllerExtensions
    {
        public static IActionResult ResultValid(this ControllerBase controller, object datos)
        {
            return new ResultValid(datos);
        }

        public static IActionResult ResultInvalid(this ControllerBase controller, string error)
        {
            return new ResultInvalid(error);
        }

        public static IActionResult ResultInvalid(this ControllerBase controller, ModelStateDictionary modelState)
        {
            return new ResultInvalid(modelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage).ToList());
        }

        public static IActionResult ResultUnexpected(this ControllerBase controller, string error)
        {
            return new ResultUnexpected(error);
        }

        public static bool Validate<T>(this ControllerBase controller, T modelo, out IActionResult resultadoInvalido)
        {
            if (modelo == null)
            {
                modelo = (T) Activator.CreateInstance(typeof(T), new object[] { });

                controller.TryValidateModel(modelo);
            }

            if (!controller.ModelState.IsValid)
                resultadoInvalido = controller.ResultInvalid(controller.ModelState);
            else
                resultadoInvalido = null;

            return resultadoInvalido != null;
        }
    }
}
