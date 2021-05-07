using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace MicroMachines.Common.Middlewares
{
    public class RequestResponseLoggingMiddleware : IMiddleware
    {
        private readonly ILogger<RequestResponseLoggingMiddleware> _logger;

        public RequestResponseLoggingMiddleware(ILogger<RequestResponseLoggingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            finally
            {
                _logger.LogInformation(
                    "{time} | {method} {url} | {statusCode}",
                    DateTime.Now,
                    context.Request?.Method,
                    context.Request?.Path.Value,
                    context.Response?.StatusCode);
            }
        }
    }
}
