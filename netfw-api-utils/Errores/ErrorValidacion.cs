using System;

namespace netfw_api_utils.Errores
{
    public class ErrorValidacion : Exception
    {
        public ErrorValidacion(string message) 
            : base(message)
        {
        }

        public ErrorValidacion(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
    }
}
