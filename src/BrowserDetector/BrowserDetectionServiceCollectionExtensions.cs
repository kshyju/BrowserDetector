using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Shyjus.BrowserDetector;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extension methods for setting up browser detection services in an <see cref="IServiceCollection" />.
    /// </summary>
    public static class BrowserDetectionServiceCollectionExtensions
    {
        /// <summary>
        /// Adds browser detection services to the specified <see cref="IServiceCollection" />.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddBrowserDetection(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.TryAddEnumerable(ServiceDescriptor.Singleton<IHttpContextAccessor, HttpContextAccessor>());
            services.AddScoped<IBrowserDetector, BrowserDetector>();
            
            return services;
        }
    }
}