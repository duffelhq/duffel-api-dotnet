using System;
using System.Collections.Generic;
using Duffel.ApiClient.Converters;

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