using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CustomOfflineCacheExample.Models;
using Microsoft.Extensions.Configuration;

namespace CustomOfflineCacheExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var vm = new HomeViewModel
            {
                Title = _configuration["AppSettings:HomePage:Title"],
                Description = _configuration["AppSettings:HomePage:Description"]
            };

            return View(vm);
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
