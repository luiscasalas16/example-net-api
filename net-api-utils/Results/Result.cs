using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace net_api_utils.Results
{
    public abstract class Result : IActionResult
    {
        public abstract ResultType Type { get; }

        public abstract object Data { get; }

        public abstract HttpStatusCode Code { get; }

        public Task ExecuteResultAsync(ActionContext context)
        {
            if (Data == null)
            {
                context.HttpContext.Response.StatusCode = (int) Code;

                return Task.CompletedTask;
            }
            else
            {
                var objectResult = new ObjectResult(Data)
                {
                    StatusCode = (int) Code
                };

                return objectResult.ExecuteResultAsync(context);
            }
        }
    }
}
