using netfw_api_utils.Results;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace netfw_api_utils.Extensions
{
    public static class ControllerExtensions
    {
        public static IHttpActionResult ResultValid(this ApiController controller, object data)
        {
            return new ResultValid(data);
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

        public static bool Validate<T>(this ApiController controller, T model, out IHttpActionResult resultinvalid)
        {
            if (model == null)
            {
                model = (T) Activator.CreateInstance(typeof(T), new object[] { });

                controller.Validate(model);
            }

            if (!controller.ModelState.IsValid)
                resultinvalid = controller.ResultInvalid(controller.ModelState);
            else
                resultinvalid = null;

            return resultinvalid != null;
        }
    }
}
