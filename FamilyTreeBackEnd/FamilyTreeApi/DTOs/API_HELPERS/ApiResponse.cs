using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.API_HELPERS
{
    public  class ApiResponse
    {
        public int StatusCode { get; set; } = 200;
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsSuccess { get; set; } = true;
        public dynamic Data { get; set; }


        public ApiResponse(int statusCode , string message = "", dynamic data = null)
        {
            this.StatusCode = statusCode;
            IsSuccess = IsSuccessByStatusCode(statusCode);
            if (IsSuccessByStatusCode(statusCode))
                SuccessMessage = message;
            else
                ErrorMessage = message;
            Data = data;

        }

        public bool IsSuccessByStatusCode(int statusCode)
        {
            switch (statusCode)
            {
                case 200:
                case 201:
                case 202:
                case 204:
                    return true;
                default:
                    return false;
            }
        }
    }
}
