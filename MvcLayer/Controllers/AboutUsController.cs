using Microsoft.AspNetCore.Mvc;

namespace MvcLayer.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
      
    }
}
