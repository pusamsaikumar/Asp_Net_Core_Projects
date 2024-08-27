using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Reflection;
using System.Text.Json;

namespace JWTRoleAuthentication.CommonLayer.Models
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {

                var response = context.Response;
                response.ContentType = "application/json";

                int statusCode;
                string message;

                switch (error)
                {
                   
                    case BadRequestException badEx:
                        statusCode = StatusCodes.Status400BadRequest;
                        message = badEx.Message;
                        break;
                    case NotFoundException notFoundEx:
                        statusCode = StatusCodes.Status404NotFound;
                        message = notFoundEx.Message; 
                        break;
                    case InternelException internelEx:
                        statusCode = StatusCodes.Status500InternalServerError;
                        message = internelEx.Message;
                        break;
                    default:
                        statusCode = StatusCodes.Status500InternalServerError;
                       message = "An internal server error occurred.";
                        break;
                }

                response.StatusCode = statusCode;

                var result = JsonSerializer.Serialize(new { 
                    StatusCode = response.StatusCode,
                    StatusMessage = message
                });
                await response.WriteAsync(result);


            }
        }


       
    }
    public class AppException : Exception
    {
        public AppException() : base()
        {

        }
        public AppException(string message) : base(message)
        {

        }
        public AppException(string message, params object[] args) : base(String.Format(message, args)) { }


    }
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {

        }

    }
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {
            
        }
    }

    public class InternelException : Exception
    {
        public InternelException(string message) : base(message)
        {
            
        }
    }
}
