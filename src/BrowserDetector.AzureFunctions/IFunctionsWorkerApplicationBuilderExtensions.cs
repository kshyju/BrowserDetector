using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shyjus.BrowserDetector.AzureFunctions;

namespace Shyjus.BrowserDetector
{
    public static class IFunctionsWorkerApplicationBuilderExtensions
    {
        /// <summary>
        /// Adds browser detection capabilities to the Azure Functions worker.
        /// </summary>
        public static IFunctionsWorkerApplicationBuilder AddBrowserDetection(this IFunctionsWorkerApplicationBuilder builder)
        {
            builder.UseMiddleware<BrowserDetectorMiddleware>();
            builder.Services.AddScoped<IBrowserDetector, FunctionsBrowserDetector>();

            return builder;
        }
    }
}
