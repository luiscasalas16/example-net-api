using Microsoft.AspNetCore.Mvc;

namespace net_api_utils.Results
{
    public class ResultValid : Result
    {
        private readonly object _data;

        public ResultValid(object data)
        {
            _data = data;
        }

        public override ResultType Type => ResultType.Valid;

        public object Data => _data;

        public override Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(_data)
            {
                StatusCode = 200
            };

            return objectResult.ExecuteResultAsync(context);
        }
    }
}
