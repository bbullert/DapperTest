using System.Net;

namespace DapperTest.Core.Exceptions
{
    public class HttpResponseException : Exception
    {
        public HttpResponseException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; set; }
    }
}
