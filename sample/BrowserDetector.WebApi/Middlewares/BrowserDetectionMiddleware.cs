using Shyjus.BrowserDetection;

namespace BrowserDetector.WebApi.Middlewares
{
    public class BrowserDetectionMiddleware
    {
        private RequestDelegate _next;
        public BrowserDetectionMiddleware(RequestDelegate next)
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
