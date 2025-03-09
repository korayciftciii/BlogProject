using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcLayer.Models;
using Services.Contracts;

namespace MvcLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServiceManager _serviceManager;

        public HomeController(ILogger<HomeController> logger,IServiceManager serviceManager)
        {
            _logger = logger;
            _serviceManager = serviceManager;
        }

        public async Task<IActionResult>  Index()
        {
            ViewData["Title"] = "Anasayfa";
            var blogs = await _serviceManager.BlogService.GetAllBlogAsync(false);
            ;
            return View(blogs);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
