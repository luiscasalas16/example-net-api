namespace net_api_utils.Errores
{
    public class ErrorConfiguracion : Exception
    {
        public ErrorConfiguracion(string message) 
            : base(message)
        {
        }

        public ErrorConfiguracion(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
    }
}
