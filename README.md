# BrowserDetector
Browser detection capabilities for asp.net core.

.NET framework 4.7 has `Browser` property on  `HttpContext.Request` which gives you information about the browser, from where there HTTP request came from. Unfortunately, ASP.NET core does not have this. This package can be used to get browser information in your ASP.NET core apps.

## How to use ?

Step 1: 
Install the nuget package


````
Install-Package Shyjus.BrowserDetector
````

Step 2: Enable the browser detection service inside the `ConfigureServices` method of `Startup.cs`.

````
public void ConfigureServices(IServiceCollection services)
{
    // Add browser detection service
    services.AddBrowserDetection();

    services.AddMvc();
}
````
Step 3: Inject `IBrowserDetector` to your controller class or view file or middleware and access the `Browser` property.

Example usage in controller code

````
public class HomeController : Controller
{
    private readonly IBrowserDetector browserDetector;
    public HomeController(IBrowserDetector browserDetector)
    {
        this.browserDetector = browserDetector;
    }
    public IActionResult Index()
    {
        var browser = this.browserDetector.Browser;
        // Use browser object as needed.

        return View();
    }
}
````

Example usage in view code

````
@inject Shyjus.BrowserDetector.IBrowserDetector browserDetector

<h2> @browserDetector.Browser.Type.ToString() </h2>
<h3> @browserDetector.Browser.Version.ToString() </h3>

````

Example usage in custom middlware

You can inject the `IBrowserDetector` to the `InvokeAsync` method.

````
public class MyCustomMiddleware
{
    private RequestDelegate next;
    public MyCustomMiddleware(RequestDelegate next)
    {
        this.next = next;
    }
    public async Task InvokeAsync(HttpContext httpContext, IBrowserDetector browserDetector)
    {
        var browser = browserDetector.Browser;

        if (browser.Type == BrowserType.Edge)
        {
            await httpContext.Response.WriteAsync("Have you tried the new chromuim based edge ?");
        }
        else
        {
            await this.next.Invoke(httpContext);
        }
    }
}
````

