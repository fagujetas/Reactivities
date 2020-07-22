using System;
using System.Net;

namespace Application.Errors
{
    public class RestException : Exception
    {
        public RestException(HttpStatusCode code, object errors = null)
        {
            Errors = errors;
            Code = code;
        }

        public HttpStatusCode Code { get; set; }
        
        public object Errors { get; set; }
    }
}