using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Shyjus.BrowserDetector;

namespace BrowserDetector.FunctionApp
{
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
}
