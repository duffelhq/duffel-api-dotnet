using System;
using System.Net;

namespace Duffel.ApiClient.Exceptions
{
    public class ApiDeserializationException : Exception
    {
        public ApiDeserializationException(Exception innerException, string payload = null, HttpStatusCode? statusCode = null) 
            : base(innerException.Message ?? "", innerException)
        {
            Payload = payload;
            StatusCode = statusCode;
        }
        
        /// <summary>
        /// Payload retrieved from the API that caused an issue
        /// </summary>
        public string Payload { get; }
        
        public HttpStatusCode? StatusCode { get; }
    }
}