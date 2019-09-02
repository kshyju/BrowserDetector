using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers
{
    // Ignore this. Used this to test something else.
    public class ProductVm
    {
        public DateTime CreatedTime { set; get; }
        public string Name { set; get; }
        public decimal Price { set; get; }
    }

    [Route("api/Product")]
    [ApiController]
    public class ProductController : Controller
    {
        IHttpContextAccessor httpContextAccessor;
        public ProductController(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        // GET: api/Product
        [HttpGet]
        public IActionResult Get()
        {
            var list = new List<ProductVm> {
                new ProductVm { Name = "P1", Price = 23.5M },
                new ProductVm { Name = "P2" , Price=42.3M} };

            if (this.httpContextAccessor.HttpContext.Request.Headers.TryGetValue("flights", out var flights))
            {
                list.Add(new ProductVm { Name = "Req header flights: " + flights });
            }
            if (this.httpContextAccessor.HttpContext.Request.Headers.TryGetValue("location", out var location))
            {
                list.Add(new ProductVm { Name = "Req header location: " + location });
            }



            return Json(list);
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            if (id==0)
            {
                return BadRequest("Missing valid id");

            }
            if (id == 1)
            {
                this.httpContextAccessor.HttpContext.Response.Headers.Add("MyApp-server-latency", "300 ms");
            
                this.httpContextAccessor.HttpContext.Response.Headers.Add("MyApp-data-center", "west-us");
            }

            return Json(new ProductVm { Name = "Product " + id, Price = id }) ;
        }

        // POST: api/Product
        [HttpPost]
        public IActionResult Post([FromBody] ProductVm value)
        {
            if (value?.Name == null)
            {
                return BadRequest("Missing valid name");
            }
            if (value.Name == "throw")
            {
                throw new Exception("Throwing exception");
            }

            value.CreatedTime = DateTime.UtcNow;
            return Ok(value);
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
