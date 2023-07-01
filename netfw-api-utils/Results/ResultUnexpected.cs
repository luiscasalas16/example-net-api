using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace netfw_api_utils.Results
{
    public class ResultUnexpected : Result
    {
        private const HttpStatusCode statusCode = HttpStatusCode.InternalServerError;

        public ResultUnexpected(HttpRequestMessage request, string error)
            : base(new List<ResultMessage> { new ResultMessage(error) }, statusCode, request)
        {
        }

        public ResultUnexpected(HttpRequestMessage request, params string[] error)
            : base(new List<ResultMessage>(error.Select(t => new ResultMessage(t))), statusCode, request)
        {
        }
    }
}
