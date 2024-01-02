using Microsoft.Extensions.Hosting;
using BrowserDetector.FunctionApp;
using Shyjus.BrowserDetector;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults((b) =>
    {
        b.UseMiddleware<MyFuncMiddleware>();

        b.AddBrowserDetection();
    })
    .Build();

host.Run();
