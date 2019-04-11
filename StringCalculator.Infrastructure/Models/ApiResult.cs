using System.Collections.Generic;
using System.Net;

namespace StringCalculator.Infrastructure.Models
{
    public class ApiResult
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public List<string> Log { get; set; }
    }
}
