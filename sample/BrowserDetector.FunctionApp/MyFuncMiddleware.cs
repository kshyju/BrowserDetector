using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Shyjus.BrowserDetector;

namespace BrowserDetector.FunctionApp
{
    public sealed class MyFuncMiddleware : IFunctionsWorkerMiddleware
    {
        public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
        {
            var logger = context.GetLogger<MyFuncMiddleware>();
            var browserDetector = context.InstanceServices.GetRequiredService<IBrowserDetector>();

            IBrowser? browser = browserDetector.Browser;
            logger.LogInformation($"MyFuncMiddleware executing. Browser:{browser?.Name} {browser?.OS}");

            await next(context);
        }
    }
}
