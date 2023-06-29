using Microsoft.AspNetCore.Mvc;

namespace net_api_utils.Results
{
    public class ResultUnexpected : Result
    {
        private readonly List<ResultMessage> _errors;

        public ResultUnexpected(string error)
        {
            _errors = new List<ResultMessage> { new ResultMessage(error) };
        }

        public override ResultType Type => ResultType.Unexpected;

        public List<ResultMessage> Errors => _errors;

        public override Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(new { errors = _errors })
            {
                StatusCode = 500
            };

            return objectResult.ExecuteResultAsync(context);
        }
    }
}
