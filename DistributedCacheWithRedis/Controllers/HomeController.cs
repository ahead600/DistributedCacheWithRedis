using DistributedCacheWithRedis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace DistributedCacheWithRedis.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDistributedCache _cache;

        public HomeController(IDistributedCache cache)
        {
            _cache = cache;
        }
        public async Task<IActionResult> Index()
        {
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddHours(1)
            };

            await _cache.SetAsync("TestString", Encoding.ASCII.GetBytes("TestValue"), options);

            var value = _cache.Get("TestString");

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
