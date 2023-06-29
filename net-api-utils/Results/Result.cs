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
            return Task.FromResult(new HttpResponseMessage(Code)
            {
                Content = new StringContent(JsonConvert.SerializeObject(Data), System.Text.Encoding.UTF8, "application/json")
            });
        }
    }
}
