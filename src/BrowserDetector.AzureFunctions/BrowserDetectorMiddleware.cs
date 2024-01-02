using Shyjus.BrowserDetector;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;

namespace Shyjus.BrowserDetector.AzureFunctions
{
    internal class BrowserDetectorMiddleware : IFunctionsWorkerMiddleware
    {
        public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
        {
            var request = await context.GetHttpRequestDataAsync();
            if (request != null)
            {
                if (request.Headers.TryGetValues("User-Agent", out var value) && value.Any())
                {
                    // temp fix until .net worker is fixed.
                    var ua = string.Join(" ", value);

                    var userAgent = ua;

                    var funcDetector = context.InstanceServices.GetRequiredService<IBrowserDetector>();
                    if (funcDetector is FunctionsBrowserDetector detector)
                    {
                        detector.Init(userAgent);
                    }
                }
            }

            await next(context);
        }
    }
}
