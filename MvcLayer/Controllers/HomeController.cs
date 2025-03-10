using System.Diagnostics;
using Entities.DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using MvcLayer.Models;
using Services.Contracts;
using X.PagedList.Extensions;


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

       

        public async Task<IActionResult>  Index(int page = 1)
        {
            //
            ViewData["Title"] = "Blog Portalý | Anasayfa";
            var blogs = await _serviceManager.BlogService.GetAllBlogAsync(false);
            var list = blogs.AsQueryable().ToPagedList(page, 3); // AsQueryable() ekledik

            return View(list);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
