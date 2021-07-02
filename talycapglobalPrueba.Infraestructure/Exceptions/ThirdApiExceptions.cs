using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace talycapglobalPrueba.Infraestructure.Exceptions
{
    public class ThirdApiExceptions : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public ThirdApiExceptions() { }

        public ThirdApiExceptions(HttpStatusCode statusCode)
            => StatusCode = statusCode;

        public ThirdApiExceptions(HttpStatusCode statusCode, string message) : base(message)
            => StatusCode = statusCode;

        public ThirdApiExceptions(HttpStatusCode statusCode, string message, Exception inner) : base(message, inner)
            => StatusCode = statusCode;
    }
}
