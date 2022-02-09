using System;

namespace Duffel.ApiClient.Exceptions
{
    public class ApiDeserializationException : Exception
    {
        public ApiDeserializationException(Exception innerException, string payload = null!) 
            : base(innerException.Message ?? "", innerException)
        {
            Payload = payload;
        }
        
        /// <summary>
        /// Payload retrieved from the API that caused an issue
        /// </summary>
        public string Payload { get; }
    }
}