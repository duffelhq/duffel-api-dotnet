using System;
using System.Collections.Generic;
using System.Net;
using Error = Duffel.ApiClient.Converters.Error;
using Metadata = Duffel.ApiClient.Converters.Metadata;

namespace Duffel.ApiClient.Exceptions
{
    public class ApiException : Exception
    {
        public ApiException(Metadata metadata, IEnumerable<Error> errors, HttpStatusCode statusCode)
        {
            Metadata = metadata;
            Errors = errors;
            StatusCode = statusCode;
        }
        public Metadata Metadata { get; }
        public IEnumerable<Error> Errors { get; }
        public HttpStatusCode StatusCode { get; }
    }
}