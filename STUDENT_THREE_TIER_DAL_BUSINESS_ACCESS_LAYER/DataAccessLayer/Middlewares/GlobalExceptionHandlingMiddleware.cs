
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataAccessLayer.Middlewares
{
    // Method: 3
    public class GlobalExceptionHandlingMiddleware : IMiddleware
    {



        private readonly ILogger _logger;
        public GlobalExceptionHandlingMiddleware(
            ILogger<GlobalExceptionHandlingMiddleware> logger
            )
        {
            _logger = logger;
        }

       
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                ProblemDetails details = new ProblemDetails();
                details.Title = ex.Message;
                details.Type = "Server Error";
                details.Detail = ex.Message;
                details.Status = (int)HttpStatusCode.InternalServerError;

                // convert json string:
                string json = JsonSerializer.Serialize(details);
                context.Request.ContentType = "application/json";
                await context.Response.WriteAsync(json);


            }

        }




        // Method:2

        //public class GlobalExceptionHandlingMiddleware
        //{

        //    private readonly RequestDelegate _next;
        //    private readonly ILogger _logger;

        //    public GlobalExceptionHandlingMiddleware(
        //        RequestDelegate next,
        //        ILogger<GlobalExceptionHandlingMiddleware> logger

        //        )
        //    {
        //        _next = next;
        //        _logger = logger;
        //    }

        //    public async Task InvokeAsync(HttpContext context)
        //    {
        //        try
        //        {
        //            await _next(context);
        //        }
        //        catch (Exception ex)
        //        {
        //            _logger.LogError(ex, ex.Message);
        //            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        //            if (ex.InnerException == null)
        //            {
        //                await context.Response.WriteAsync(ex.Message);
        //            }

        //        }

        //    }
        //}
    }
}
