using Microsoft.AspNetCore.Http;

namespace WebCommon.Middleware
{
    public class RequestCountMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestCountMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            int count = 1;
            if (context.Request.Cookies.ContainsKey("requestCount"))
            {
                count = int.Parse(context.Request.Cookies["requestCount"]) + 1;
            }
            context.Response.Cookies.Append("requestCount", count.ToString());
            await _next(context);
        }
    }
}