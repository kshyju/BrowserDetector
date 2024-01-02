
# Shyjus.BrowserDetector.AzureFunctions

Browser detection capabilities for Azure functions .NET Isolated model.

This library does

1. Browser detection
2. Device type detection
3. Operating System detection

**Step 1:**
Install the [BrowserDetector.AzureFunctions nuget package](https://www.nuget.org/packages/Shyjus.BrowserDetector.AzureFunctions/)


````
Install-Package Shyjus.BrowserDetector.AzureFunctions
````

**Step 2:** Enable the browser detection service by calling `AddBrowserDetection` method on `IFunctionsWorkerApplicationBuilder` in your startup code.

```csharp
using Microsoft.Extensions.Hosting;
using BrowserDetector;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults((b) =>
    {
        b.AddBrowserDetection();
    })
    .Build();

host.Run();

````
**Step 3:** Inject `IBrowserDetector` to your function class e and access the `Browser` property.

### Example usage

```csharp
public class Function1
{
    private readonly ILogger _logger;
    private readonly IBrowserDetector _detector;

    public Function1(ILoggerFactory loggerFactory, IBrowserDetector detector)
    {
        _logger = loggerFactory.CreateLogger<Function1>();
        _detector = detector ?? throw new ArgumentNullException(nameof(detector));
    }

    [Function("Function1")]
    public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
    {
        var response = req.CreateResponse(HttpStatusCode.OK);
        response.WriteString($"Browser: {_detector.Browser?.ToString()}");

        return response;
    }
}
````



### Example usage in functions middleware

You can get instance of the `IBrowserDetector` from FunctionContext.

```csharp
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
````
and make sure you register this middleware after enabling the browser detection feature.

```csharp
using Microsoft.Extensions.Hosting;
using BrowserDetector;
using BrowserDetector.FunctionApp;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults((b) =>
    {
        b.AddBrowserDetection();
        b.UseMiddleware<MyFuncMiddleware>();
    })
    .Build();

host.Run();
```
