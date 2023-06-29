using System.Net;

namespace netfw_api_utils.Results
{
    public class ResultValid : Result
    {
        private readonly object _data;

        public ResultValid(object data)
        {
            _data = data;
        }

        public override ResultType Type => ResultType.Valid;

        public override object Data => _data;

        public override HttpStatusCode Code => HttpStatusCode.OK;
    }
}
