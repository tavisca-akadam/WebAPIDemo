using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIDemo.Middleware
{
    public class Logger
    {
        private readonly ILogger<Logger> logger;
        private readonly RequestDelegate next;

        public Logger(ILogger<Logger> logger, RequestDelegate next)
        {
            this.logger = logger;
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Items["CorrelationId"] = Guid.NewGuid().ToString();
            logger.LogInformation($"About to start {context.Request.Method} {context.Request.GetDisplayUrl()} request");

            await next(context);

            logger.LogInformation($"Request completed with status code: {context.Response.StatusCode} ");
        }
    }
}
