# BrowserDetector
[![NuGet version (BrowserDetector)](https://img.shields.io/nuget/v/Shyjus.BrowserDetector.svg?style=flat-square)](https://www.nuget.org/packages/Shyjus.BrowserDetector/)

Browser detection capabilities for asp.net core Web API. 

### Supported frameworks

 - .NET6.0
 - .NET7.0
 - .NET8.0

This library does

1. Browser detection
2. Device type detection
3. Operating System detection

.NET framework 4.7 has `Browser` property on  `HttpContext.Request` which gives you information about the browser, from where there HTTP request came from. Unfortunately, ASP.NET core does not have this. This package can be used for browser & device detection in your ASP.NET core apps.




## Browsers supported

| Name    | Operating System | Device type |
| ------------- | ------------- | ------------- |
| Chrome  | Windows  | Desktop  |
| Chrome  | Mac OS  | Desktop  |
| Chrome  | iOS  | Mobile  |
| Chrome  | iOS  | Tablet  |
| Chrome  | Android  | Mobile  |
| Chrome  | Android  | Tablet  |
| Internet Explorer 11  | Windows  | Desktop  |
| Edge  | Windows  | Desktop  |
| Edge  | iOS  | Tablet  |
| Edge  | iOS  | Mobile  |
| Edge  | Android  | Mobile  |
| EdgeChromium  | Windows  | Desktop  |
| EdgeChromium  | OSX  | Desktop  |
| Opera  | Windows  | Desktop  |
| Opera  | Mac OS  | Desktop  |
| Opera  | iOS  | Mobile  |
| Opera  | iOS  | Tablet  |
| Safari  | Windows  | Desktop  |
| Safari  | Mac OS  | Desktop  |
| Safari  | iOS  | Mobile  |
| Safari  | iOS  | Tablet  |
| Firefox  | Windows  | Desktop  |
| Firefox  | Mac OS  | Desktop  |
| Firefox  | iOS  | Mobile  |
| Firefox  | iOS  | Tablet  |

If you do not see a specific browser/os/device type combo, please [open an issue](https://github.com/kshyju/BrowserDetector/issues/new)

## How to use ?

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

#### Example usage in controller code

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

#### Example usage in view code

````
@inject Shyjus.BrowserDetection.IBrowserDetector browserDetector

<h2> @browserDetector.Browser.Name </h2>
<h3> @browserDetector.Browser.Version </h3>
<h3> @browserDetector.Browser.OS </h3>
<h3> @browserDetector.Browser.DeviceType </h3>

````

#### Example usage in custom middleware

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

### Interpreting the Name values returned by `IBrowser.Name`

 * Firefox - Firefox browser.
 * EdgeChromium - The new Chromium based Microsoft Edge browser.
 * Edge - The legacy Edge browser.
 * Safari - The Safari browser.
 * Chrome - The Chrome browser.

### What is the Perf impact on adding this package ?

I ran benchmarks on Safari and Chrome desktop user agents and those seems to return the results around **~ 1 micro second.** Heap allocation varies based on the input.

```
|         Method |     Mean |
|--------------- |---------:|
| Chrome_Windows | 1.057 us |
| Safari_Windows | 1.093 us |
````

> 1 micro second is one millionth of a second.


