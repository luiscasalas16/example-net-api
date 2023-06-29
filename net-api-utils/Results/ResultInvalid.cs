using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace net_api_utils.Results
{
    public class ResultInvalid : Result
    {
        private readonly List<ResultMessage> _errors;

        public ResultInvalid(string error)
        {
            _errors = new List<ResultMessage> { new ResultMessage(error) };
        }

        public ResultInvalid(List<string> errors)
        {
            _errors = new List<ResultMessage> (errors.Select(t => new ResultMessage(t)).ToList());
        }

        public ResultInvalid(ModelStateDictionary modelState)
        {
            _errors = modelState.Values.SelectMany(m => m.Errors).Select(e => new ResultMessage(e.ErrorMessage)).ToList();
        }

        public override ResultType Type => ResultType.Invalid;

        public List<ResultMessage> Errors => _errors;

        public override Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(new { errors = _errors })
            {
                StatusCode = 400
            };

            return objectResult.ExecuteResultAsync(context);
        }
    }
}
