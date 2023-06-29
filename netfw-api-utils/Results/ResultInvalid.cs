using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http.ModelBinding;

namespace netfw_api_utils.Results
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

        public override object Data => new { errores = _errors };

        public override HttpStatusCode Code => HttpStatusCode.BadRequest;
    }
}
