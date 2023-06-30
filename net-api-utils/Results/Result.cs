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
            var objectResult = new ObjectResult(Data)
            {
                StatusCode = (int) Code
            };

            return objectResult.ExecuteResultAsync(context);
        }
    }
}
