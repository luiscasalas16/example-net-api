using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace netfw_api_utils.Results
{
    public abstract class Result : IHttpActionResult
    {
        public abstract ResultType Type { get; }

        public abstract object Data { get; }

        public abstract HttpStatusCode Code { get; }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(new HttpResponseMessage(Code)
            {
                Content = new StringContent(JsonConvert.SerializeObject(Data), System.Text.Encoding.UTF8, "application/json")
            });
        }
    }
}
