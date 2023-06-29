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
        public abstract ResultType ResultadoTipo { get; }

        public abstract object Contenido { get; }

        public abstract HttpStatusCode Estado { get; }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(new HttpResponseMessage(Estado)
            {
                Content = new StringContent(JsonConvert.SerializeObject(Contenido), System.Text.Encoding.UTF8, "application/json")
            });
        }
    }
}
