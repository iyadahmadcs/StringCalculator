using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using StringCalculator.Infrastructure.Models;
using System;
using System.Net;
using System.Threading.Tasks;

namespace StringCalculator.Infrastructure.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var result = new ApiResult
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Message = exception.Message
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)result.StatusCode;
            var response = JsonConvert.SerializeObject(result);
            return context.Response.WriteAsync(response);
        }

    }
}
