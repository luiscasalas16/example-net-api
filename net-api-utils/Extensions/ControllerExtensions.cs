using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using net_api_utils.Results;

namespace net_api_utils.Extensions
{
    public static class ControllerExtensions
    {
        public static IActionResult ResultValid(this ControllerBase controller, object data)
        {
            return new ResultValid(data);
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

        public static bool Validate<T>(this ControllerBase controller, T model, out IActionResult resultinvalid)
        {
            if (model == null)
            {
                model = (T) Activator.CreateInstance(typeof(T), new object[] { });

                controller.TryValidateModel(model);
            }

            if (!controller.ModelState.IsValid)
                resultinvalid = controller.ResultInvalid(controller.ModelState);
            else
                resultinvalid = null;

            return resultinvalid != null;
        }
    }
}
