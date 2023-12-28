
# BrowserDetector

Browser detection capabilities for asp.net core.



This library does

1. Browser detection
2. Device type detection
3. Operating System detection

**Step 1:**
Install the [BrowserDetector nuget package](https://www.nuget.org/packages/Shyjus.BrowserDetector/)


````
Install-Package Shyjus.BrowserDetector
````

**Step 2:** Enable the browser detection service by calling `AddBrowserDetection` method on `IServiceCollection` in your startup code.

````
services.AddBrowserDetection();
````
**Step 3:** Inject `IBrowserDetector` to your controller class or view file or middleware and access the `Browser` property.

### Example usage in controller code

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

### Example usage in view code

````
@inject Shyjus.BrowserDetection.IBrowserDetector browserDetector

<h2> @browserDetector.Browser.Name </h2>
<h3> @browserDetector.Browser.Version </h3>
<h3> @browserDetector.Browser.OS </h3>
<h3> @browserDetector.Browser.DeviceType </h3>

````

### Example usage in custom middleware

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

### Interpreting the `Name` value returned by `IBrowser.Name`

 * Firefox - Firefox browser.
 * EdgeChromium - The new Chromium based Microsoft Edge browser.
 * Edge - The legacy Edge browser.
 * Safari - The Safari browser.
 * Chrome - The Chrome browser.