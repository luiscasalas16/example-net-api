using System.Net;

namespace net_api_utils.Results
{
    public class ResultUnexpected : Result
    {
        private const HttpStatusCode statusCode = HttpStatusCode.InternalServerError;

        public ResultUnexpected(string error)
            : base(new List<ResultMessage> { new ResultMessage(error) }, statusCode)
        {
        }

        public ResultUnexpected(params string[] error)
            : base(new List<ResultMessage>(error.Select(t => new ResultMessage(t))), statusCode)
        {
        }
    }
}
