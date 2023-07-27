using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.errors
{
    public class ApiException
    {
        private string message;
        private object value;

        public ApiException(int statusCode, int message, int details)
        {
            StatusCode = statusCode;
            Message = message;
            Details = details;
        }

        public ApiException(int statusCode, string message, object value)
        {
            StatusCode = statusCode;
            this.message = message;
            this.value = value;
        }

        public int StatusCode { get; set; }
        public int Message { get; set; }
        public int Details { get; set; }    
    }
}