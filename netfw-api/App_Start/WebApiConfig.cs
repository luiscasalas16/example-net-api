using ApiMultiPartFormData;
using netfw_api_utils.Errores;
using System;
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

            config.Routes.MapHttpRoute("ApiId", "{controller}/{id}", new { id = RouteParameter.Optional }, new { id = @"\d+" });

            config.Routes.MapHttpRoute("ApiAction", "{controller}/{action}");

            config.Routes.MapHttpRoute("ApiGet", "{controller}", new { action = "Get" }, new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) });
            config.Routes.MapHttpRoute("ApiPost", "{controller}", new { action = "Post" }, new { httpMethod = new HttpMethodConstraint(HttpMethod.Post) });
            config.Routes.MapHttpRoute("ApiPut", "{controller}", new { action = "Put" }, new { httpMethod = new HttpMethodConstraint(HttpMethod.Put) });
            config.Routes.MapHttpRoute("ApiDelete", "{controller}", new { action = "Delete" }, new { httpMethod = new HttpMethodConstraint(HttpMethod.Delete) });

            // Register multipart/form-data formatter.
            config.Formatters.Add(new MultipartFormDataFormatter());

            // Register default error handler.
            config.Services.Replace(typeof(IExceptionHandler), new DefaultExceptionHandler());
        }
    }
}
