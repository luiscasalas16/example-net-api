using Microsoft.AspNetCore.Mvc;

namespace net_api_utils.Results
{
    public abstract class Result : IActionResult
    {
        public abstract ResultType Type { get; }

        public abstract Task ExecuteResultAsync(ActionContext context);
    }
}
