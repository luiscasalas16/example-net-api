using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http.ModelBinding;

namespace netfw_api_utils.Results
{
    public class ResultadoInvalido : Result
    {
        private readonly List<ResultadoMensaje> _errores;

        public ResultadoInvalido(string error)
        {
            _errores = new List<ResultadoMensaje> { new ResultadoMensaje(error) };
        }

        public ResultadoInvalido(List<string> errores)
        {
            _errores = new List<ResultadoMensaje> (errores.Select(t => new ResultadoMensaje(t)).ToList());
        }

        public ResultadoInvalido(ModelStateDictionary modelState)
        {
            _errores = modelState.Values.SelectMany(m => m.Errors).Select(e => new ResultadoMensaje(e.ErrorMessage)).ToList();
        }

        public override ResultType ResultadoTipo => ResultType.Invalid;

        public List<ResultadoMensaje> Errores => _errores;

        public override object Contenido => new { errores = _errores };

        public override HttpStatusCode Estado => HttpStatusCode.BadRequest;
    }
}
