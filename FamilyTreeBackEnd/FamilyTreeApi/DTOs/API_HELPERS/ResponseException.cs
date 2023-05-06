using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.API_HELPERS
{
    public class ResponseException:Exception
    {
        public string ErrorMessage { get; set; }
        public int StatusCode { get; set; } = 500;
        public dynamic Data { get; set; }
        public ResponseException(ApiResponse response)
        {
            ErrorMessage = response.ErrorMessage;
            StatusCode = response.StatusCode;
            Data = response.Data;
        }

        public ResponseException(int statusCode , string message , dynamic data = null)
        {
            StatusCode = statusCode;
            ErrorMessage = message;
            Data = data;
        }
    }
}
