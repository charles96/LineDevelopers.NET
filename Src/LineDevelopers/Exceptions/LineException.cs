using System.Net;

namespace Line
{
    public class LineException : Exception
    {
        public LineException() { }

        public LineException(HttpStatusCode httpStatusCode,
                             string message,
                             IList<Detail>? details = null) : base(message) 
        {
            this.HttpStatusCode = httpStatusCode;
            this.Details = details;
        }

        public LineException(string message) : base(message) { }
        
        public HttpStatusCode HttpStatusCode { get; set; }

        public IList<Detail>? Details { get; set; }
    }
}
