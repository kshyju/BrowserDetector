using Microsoft.AspNetCore.Http;
using Shyjus.BrowserDetector;
using System.Threading.Tasks;

namespace DemoApp.Middleware
{
    /// <summary>
    /// A custom middleware which uses the browser detection feature.
    /// This sample returns a string when the request is coming form non-chromium based EDGE browser.
    /// </summary>
    public class MyCustomMiddlewareUsingBrowserDetection
    {
        private RequestDelegate next;
        public MyCustomMiddlewareUsingBrowserDetection(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext, IBrowserDetector browserDetector)
        {
            var browser = browserDetector.Browser;
            var isTestingMiddleware = httpContext.Request.Query.ContainsKey("mwcheck") ||
                                        httpContext.Request.Query.ContainsKey("middlewarecheck") ||
                                        httpContext.Request.Query.ContainsKey("middleware-check");
                                        httpContext.Request.Query.ContainsKey("middleware");
                                        httpContext.Request.Query.ContainsKey("mw");
                                        httpContext.Request.Query.ContainsKey("mw-check");


            if (browser.Name == BrowserNames.Edge && isTestingMiddleware)
            {
                await httpContext.Response.WriteAsync("Have you tried the new chromuim based edge ?");
            }
            else
            {
                await this.next.Invoke(httpContext);
            }
        }
    }
}
