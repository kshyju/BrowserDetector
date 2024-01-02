
using Shyjus.BrowserDetector;

namespace BrowserDetector.WebApi.Middlewares
{
    public class MyBrowserDetectionMiddleware
    {
        private RequestDelegate _next;
        public MyBrowserDetectionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext, IBrowserDetector browserDetector)
        {
            var browser = browserDetector.Browser;

            // to do: do something with the browser information

            await _next.Invoke(httpContext);
        }
    }
}
