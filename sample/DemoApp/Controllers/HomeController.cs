using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace DemoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public HomeController(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("headers")]
        public string Headers()
        {
            var headers = this.httpContextAccessor.HttpContext.Request.Headers;
            var requestHeader = string.Join(", ", headers.Select(a => a.Key + ":" + a.Value));

            return requestHeader;
        }
    }
}
