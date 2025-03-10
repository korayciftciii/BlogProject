using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System.Threading.Tasks;

namespace MvcLayer.Controllers
{
    public class AboutUsController : Controller
    {
        private readonly IServiceManager _serviceManager;
        public AboutUsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
   
        public async Task<IActionResult> Index()
        {
            var content = await _serviceManager.AboutService.GetAboutContentAsync(false);
            return View(content);
        }
      
    }
}
