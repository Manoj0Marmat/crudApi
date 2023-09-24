using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; }
        public string? Message { get; set; }
        public ApiResponse(int statusCode, string? message = null)
        {
            this.StatusCode = statusCode;
            this.Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string? GetDefaultMessageForStatusCode(int statusCode){
            return statusCode switch{
                400 => "Bad Request: The server could not understand the request.",
                401 => "Unauthorized: Authentication is required to access the resource.",
                404 => "Not Found: The requested resource could not be found.",
                500 => "Internal Server Error: An unexpected error occurred on the server.",
                _ => null
            };
        }
    }
}