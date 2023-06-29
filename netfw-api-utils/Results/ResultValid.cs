using System.Net;

namespace netfw_api_utils.Results
{
    public class ResultadoValido : Result
    {
        private readonly object _datos;

        public ResultadoValido(object datos)
        {
            _datos = datos;
        }

        public override ResultType ResultadoTipo => ResultType.Valid;

        public override object Contenido => _datos;

        public override HttpStatusCode Estado => HttpStatusCode.OK;
    }
}
