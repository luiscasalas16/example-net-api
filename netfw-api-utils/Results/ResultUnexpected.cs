using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace netfw_api_utils.Results
{
    public class ResultadoInesperado : Result
    {
        private readonly List<ResultadoMensaje> _errores;

        public ResultadoInesperado(string error)
        {
            _errores = new List<ResultadoMensaje> { new ResultadoMensaje(error) };
        }

        public ResultadoInesperado(params string [] error)
        {
            _errores = new List<ResultadoMensaje> (error.Select(t => new ResultadoMensaje(t)));
        }

        public override ResultType ResultadoTipo => ResultType.Unexpected;

        public List<ResultadoMensaje> Errores => _errores;

        public override object Contenido => new { errores = _errores };

        public override HttpStatusCode Estado => HttpStatusCode.InternalServerError;
    }
}
