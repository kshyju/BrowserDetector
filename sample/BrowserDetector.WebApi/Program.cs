using BrowserDetector.WebApi.Middlewares;
using Shyjus.BrowserDetector;
namespace BrowserDetector.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddBrowserDetection();
            builder.Services.AddLogging();

            var app = builder.Build();

            app.MapControllers();
            
            app.UseMiddleware<MyBrowserDetectionMiddleware>();

            app.Run();
        }
    }
}
