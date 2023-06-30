using ApiMultiPartFormData;
using netfw_api_utils.Errores;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Routing;

namespace netfw_api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            // Register routes.
            config.Routes.MapHttpRoute(name: "DefaultApi", routeTemplate: "{controller}/{action}");
            config.Routes.MapHttpRoute(name: "DefaultApiGet", routeTemplate: "{controller}", new { action = "Get" }, new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) });
            config.Routes.MapHttpRoute(name: "DefaultApiPost", routeTemplate: "{controller}", new { action = "Post" }, new { httpMethod = new HttpMethodConstraint(HttpMethod.Post) });

            // Register multipart/form-data formatter.
            config.Formatters.Add(new MultipartFormDataFormatter());

            // Register default error handler.
            config.Services.Replace(typeof(IExceptionHandler), new DefaultExceptionHandler());
        }
    }
}
