using System;
using System.Collections.Generic;
using Error = Duffel.ApiClient.Interfaces.Converters.Error;
using Metadata = Duffel.ApiClient.Interfaces.Converters.Metadata;

namespace Duffel.ApiClient.Interfaces.Exceptions
{
    public class ApiException : Exception
    {
        public ApiException(Metadata metadata, IEnumerable<Error> errors)
        {
            Metadata = metadata;
            Errors = errors;
        }
        public Metadata Metadata { get; }
        public IEnumerable<Error> Errors { get; }
    }
}