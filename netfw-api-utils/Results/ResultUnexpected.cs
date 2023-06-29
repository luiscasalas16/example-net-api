using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace netfw_api_utils.Results
{
    public class ResultUnexpected : Result
    {
        private readonly List<ResultMessage> _errors;

        public ResultUnexpected(string error)
        {
            _errors = new List<ResultMessage> { new ResultMessage(error) };
        }

        public ResultUnexpected(params string [] error)
        {
            _errors = new List<ResultMessage> (error.Select(t => new ResultMessage(t)));
        }

        public override ResultType Type => ResultType.Unexpected;

        public List<ResultMessage> Errors => _errors;

        public override object Data => new { errores = _errors };

        public override HttpStatusCode Code => HttpStatusCode.InternalServerError;
    }
}
